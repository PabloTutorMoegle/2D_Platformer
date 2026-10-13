
using UnityEngine;

public class LevelPlayerSetup : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Sprite levelSprite;

    private void Start()
    {
        PlayerController player =
            FindFirstObjectByType<PlayerController>();

        if (player == null)
        {
            return;
        }

        if (spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
        }

        if (levelSprite != null)
        {
            SpriteRenderer spriteRenderer =
                player.GetComponentInChildren<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = levelSprite;
            }
        }
    }
}
