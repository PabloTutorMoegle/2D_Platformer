using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private MovementSystem _mv;
    private HealthSystem _hs;
    private SpriteRenderer _sr;
    private Animator _anim;

    public GameObject endDetector;

    //Health variables
    public float maxHealth = 1f;
    public float starterHealth = 1f;
    public float currentHealth;

    //Movement variables
    public float moveSpeed = 2f;
    public Vector3 moveDirection = new Vector3(-1f, 0f, 0f);

    private void Awake()
    {
        TryGetComponent<MovementSystem>(out _mv);
        TryGetComponent<HealthSystem>(out _hs);
        TryGetComponent<SpriteRenderer>(out _sr);
        TryGetComponent<Animator>(out _anim);
    }

    private void Start()
    {
        _hs.SetMaxHealth(maxHealth);
        _hs.SetHealth(starterHealth);
        currentHealth = _hs.GetCurrentHealth();
    }

    private void Update()
    {
        _mv.MoveLinearVelocity(moveDirection, moveSpeed);
    }
}
