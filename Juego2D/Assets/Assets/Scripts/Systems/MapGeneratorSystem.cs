using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct TilePrefab
    {
        public int num;
        public GameObject prefab;
    }

    public TilePrefab[] tilePrefabs;
    private Dictionary<int, GameObject> prefabDict;
    private ArrayList mapData;
    private Vector3 position = Vector3.zero;
    private ArrayList mapFiles = new ArrayList() { "map1.txt", "map2.txt", "map3.txt" };

    private void Awake()
    {
        prefabDict = new Dictionary<int, GameObject>();
        foreach (var tile in tilePrefabs)
        {
            prefabDict[tile.num] = tile.prefab;
        }
    }

    private void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        mapData = new ArrayList();
        
        //Pick random map file
        string path = Application.dataPath + "/Resources/" + mapFiles[Random.Range(0, mapFiles.Count)];
        
        if (!System.IO.File.Exists(path))
        {
            Debug.LogError("Map file not found at: " + path);
            return;
        }
        string[] lines = System.IO.File.ReadAllLines(path);

        if (lines.Length < 3)
        {
            Debug.LogError("Map file format incorrect. Must have at least 3 lines (height, width, and data).");
            return;
        }

        int height, width;
        if (!int.TryParse(lines[0], out height) || !int.TryParse(lines[1], out width))
        {
            Debug.LogError("Failed to parse map height or width.");
            return;
        }

        List<int> tiles = new List<int>();
        for (int i = 2; i < lines.Length; i++)
        {
            string[] nums = lines[i].Split(new char[] { ' ', ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var numStr in nums)
            {
                int tileNum;
                if (int.TryParse(numStr, out tileNum))
                {
                    tiles.Add(tileNum);
                }
            }
        }

        if (tiles.Count != height * width)
        {
            Debug.LogError($"Tile count ({tiles.Count}) does not match specified dimensions ({height}x{width}).");
            return;
        }

        float tileWidth = 18f;
        float tileHeight = 10f;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int tile = tiles[y * width + x];
                position = new Vector3(x * tileWidth, (height - 1 - y) * tileHeight, 0);
                if (tile != 0 && prefabDict.ContainsKey(tile))
                {
                    Instantiate(prefabDict[tile], position, Quaternion.identity);
                    mapData.Add(tile);
                }
            }
        }
    }
}
