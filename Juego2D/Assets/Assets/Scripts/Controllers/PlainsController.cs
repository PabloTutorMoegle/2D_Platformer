using UnityEngine;

public class PlainsController : MonoBehaviour
{
    private MovementSystem _mv;
    private RotationSystem _rs;
    private HealthSystem _hs;
    private SpriteRenderer _sr;
    private Animator _anim;

    private Transform _player;

    //Health variables
    public float maxHealth = 1f;
    public float starterHealth = 1f;
    public float currentHealth;

    //Movement variables
    public float moveSpeed = 2f;
    public Vector3 moveDirection;

    private void Awake()
    {
        TryGetComponent<MovementSystem>(out _mv);
        TryGetComponent<RotationSystem>(out _rs);
        TryGetComponent<HealthSystem>(out _hs);
        _sr = GetComponentInChildren<SpriteRenderer>(true);
        _anim = GetComponentInChildren<Animator>(true);

        FindPlayer();
    }

    private void Start()
    {
        _hs.SetMaxHealth(maxHealth);
        _hs.SetHealth(starterHealth);
        currentHealth = _hs.GetCurrentHealth();

        FindPlayer();
    }

    private void FindPlayer()
    {
        PlayerController playerController =
            FindFirstObjectByType<PlayerController>();

        if (playerController != null)
        {
            _player = playerController.transform;
        }
    }

    private void Update()
    {
        moveDirection = (_player.position - transform.position).normalized;

        _mv.MoveLinearVelocity(moveDirection, moveSpeed);
        _rs.TurnTowards(Vector3.SignedAngle(Vector3.right, moveDirection, Vector3.forward));
    }
}
