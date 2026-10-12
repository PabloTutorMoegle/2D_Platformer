using UnityEngine;

public class EndDetector : MonoBehaviour
{
    public GameObject enemyControllerObject;
    private EnemyController _ec;

    private void Awake()
    {
        _ec = enemyControllerObject.TryGetComponent<EnemyController>(out _ec) ? _ec : null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _ec.TryGetComponent<MovementSystem>(out MovementSystem mv);
        if (mv != null)
        {
            Vector3 currentDirection = _ec.moveDirection;
            Vector3 newDirection = new Vector3(-currentDirection.x, currentDirection.y, 0f);
            _ec.moveDirection = newDirection;
        }
    }
}