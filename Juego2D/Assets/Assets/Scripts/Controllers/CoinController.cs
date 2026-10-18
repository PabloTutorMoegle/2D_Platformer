using UnityEngine;

public class CoinController : MonoBehaviour
{
    private CoinManager coinManager;
    private int coinIndex;
    private bool collected = false;
    private SpriteRenderer spriteRenderer;
    private Sprite normalSprite;
    private Sprite nextCoinSprite;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(true);

        if (spriteRenderer != null)
        {
            normalSprite = spriteRenderer.sprite;
        }
    }
    public void Initialize(
        CoinManager manager,
        int index,
        Sprite highlightSprite)
    {
        coinManager = manager;
        coinIndex = index;
        nextCoinSprite = highlightSprite;
    }
    public void SetAsNextCoin(bool isNext)
    {
        if (spriteRenderer == null)
            return;

        spriteRenderer.sprite = isNext && nextCoinSprite != null
            ? nextCoinSprite
            : normalSprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collected)
            return;

        PointsSystem pointsSystem =
            collision.GetComponentInParent<PointsSystem>();

        if (pointsSystem == null || coinManager == null)
            return;

        collected = true;

        coinManager.CollectCoin(
            coinIndex,
            pointsSystem,
            this
        );
    }
    public void MarkCollected()
    {
        Destroy(gameObject);
    }
    public int GetCoinIndex()
    {
        return coinIndex;
    }
}
