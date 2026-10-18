using UnityEngine;

public class CoinController : MonoBehaviour
{
    private CoinManager coinManager;
    private int coinIndex;
    private bool collected = false;

    public void Initialize(CoinManager manager, int index)
    {
        coinManager = manager;
        coinIndex = index;
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
}
