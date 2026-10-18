
using UnityEngine;

public class LevelPlayerSetup : MonoBehaviour
{
    public Transform spawnPoint;
    public Sprite levelSprite;
    public RuntimeAnimatorController levelAnimator;
    public Vector3 levelScale = Vector3.one;

    private void Start()
    {
        PlayerController player =
            PlayerPersistence.PersistentPlayer;

        if (player == null)
        {
            player = FindFirstObjectByType<PlayerController>();
        }

        if (player == null)
        {
            return;
        }

        if (spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
        }

        if (player.VisualRoot != null)
        {
            player.VisualRoot.localScale = levelScale;
        }

        Animator animator =
            player.GetComponentInChildren<Animator>(true);

        if (animator != null && levelAnimator != null)
        {
            animator.runtimeAnimatorController = levelAnimator;
        }

        SpriteRenderer spriteRenderer =
            player.GetComponentInChildren<SpriteRenderer>(true);

        if (spriteRenderer != null && levelSprite != null)
        {
            spriteRenderer.sprite = levelSprite;
        }
    }
}
