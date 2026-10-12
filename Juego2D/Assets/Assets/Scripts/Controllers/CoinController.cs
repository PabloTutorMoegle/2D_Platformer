using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int points = 100;
    private bool _collected = false;
    public GameObject levelManagerObject;
    private LevelManager _lm;

    private void Awake()
    {
        _lm = levelManagerObject.TryGetComponent<LevelManager>(out _lm) ? _lm : null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_collected)
            return;

        PointsSystem _ps = collision.TryGetComponent<PointsSystem>(out _ps) ? _ps : null;

        if (_ps == null)
            return;
        if (_lm == null)
            return;
        _collected = true;

        Destroy(gameObject);
        _ps.AddPoints(points);
        _lm.CollectCoin();
    }
}
