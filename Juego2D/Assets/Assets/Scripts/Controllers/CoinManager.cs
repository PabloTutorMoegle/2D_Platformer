
using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Serializable]
    private class CoinData
    {
        public Vector3 position;
        public int basePoints;
        public int orderedPoints;
    }

    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private string levelFileName = "Level1";
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Sprite nextCoinSprite;
    private readonly List<CoinController> spawnedCoins = new List<CoinController>();
    private readonly List<CoinData> coins = new List<CoinData>();
    private int nextExpectedCoin = 0;

    public int NextExpectedCoin => nextExpectedCoin;
    public int TotalCoins => coins.Count;

    private void Awake()
    {
        if (coinPrefab == null)
        {
            return;
        }

        if (levelManager == null)
            levelManager = FindFirstObjectByType<LevelManager>();

        if (levelManager == null)
        {
            return;
        }

        LoadCoins();
        SpawnCoins();

        levelManager.SetTotalCoins(coins.Count);
    }
    private void LoadCoins()
    {
        coins.Clear();

        TextAsset file = Resources.Load<TextAsset>(
            "Levels/" + levelFileName
        );

        if (file == null)
        {
            return;
        }

        string[] lines = file.text.Split(
            new[] { '\r', '\n' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string rawLine in lines)
        {
            string line = rawLine.Trim();

            if (line.Length == 0 || line.StartsWith("#"))
                continue;

            string[] values = line.Split(',');
            if (values.Length != 5)
            {
                continue;
            }
            if (!TryParseFloat(values[0], out float x) || !TryParseFloat(values[1], out float y) || !TryParseFloat(values[2], out float z) || !int.TryParse(values[3].Trim(), out int basePoints) || !int.TryParse(values[4].Trim(), out int orderedPoints))
            {
                continue;
            }
            coins.Add(new CoinData
            {
                position = new Vector3(x, y, z),
                basePoints = basePoints,
                orderedPoints = orderedPoints
            });
        }
    }
    private bool TryParseFloat(string value, out float result)
    {
        return float.TryParse(
            value.Trim(),
            NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out result
        );
    }
    private void SpawnCoins()
    {
        for (int i = 0; i < coins.Count; i++)
        {
            CoinData data = coins[i];

            GameObject coinObject = Instantiate(
                coinPrefab,
                data.position,
                Quaternion.identity
            );

            CoinController coin =
                coinObject.GetComponent<CoinController>();

            if (coin == null)
            {
                Destroy(coinObject);
                continue;
            }

            coin.Initialize(this, i, nextCoinSprite);
            spawnedCoins.Add(coin);

            UpdateNextCoinSprite();
        }
    }
    public void CollectCoin(int coinIndex, PointsSystem pointsSystem, CoinController coin)
    {
        if (coin == null || pointsSystem == null)
            return;

        if (coinIndex < 0 || coinIndex >= coins.Count)
            return;

        int points;

        if (coinIndex == nextExpectedCoin)
        {
            points = coins[coinIndex].orderedPoints;
            nextExpectedCoin++;
        }
        else
        {
            points = coins[coinIndex].basePoints;
        }

        pointsSystem.AddPoints(points);

        if (levelManager != null)
            levelManager.CollectCoin();

        coin.MarkCollected();

        UpdateNextCoinSprite();
    }

    private void UpdateNextCoinSprite()
    {
        foreach (CoinController coin in spawnedCoins)
        {
            if (coin == null)
                continue;

            coin.SetAsNextCoin(
                coin.GetCoinIndex() == nextExpectedCoin
            );
        }
    }
}
