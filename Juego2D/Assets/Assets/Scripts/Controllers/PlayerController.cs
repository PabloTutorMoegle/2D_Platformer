using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    public Transform VisualRoot { get; private set; }
    private InputSystem_Actions _actions;
    private MovementSystem _mv;
    private HealthSystem _hs;
    private InventorySystem _inventory;
    private PointsSystem _ps;
    private SpriteRenderer _sr;
    private Animator _anim;
    // private MeleeAttackSystem _ma;

    // private bool _isAttacking = false;
    // private float attackTimer = 0.3f;
    
    // public GameObject attackHitbox;
    //Health variables
    public float maxHealth;
    public float starterHealth;
    public float currentHealth;

    //Movement variables
    public float moveSpeed = 5f;
    public Vector3 moveDirection;
    private Vector2 _movementInput;
    public float jumpForce;
    bool _isGrounded = true;


    private void Awake()
    {
        _actions = new InputSystem_Actions();
        _actions.Player.Move.performed += OnMove;
        _actions.Player.Move.canceled += OnMove;

        TryGetComponent<MovementSystem>(out _mv);
        TryGetComponent<PointsSystem>(out _ps);
        TryGetComponent<HealthSystem>(out _hs);
        _sr = GetComponentInChildren<SpriteRenderer>(true);
        _anim = GetComponentInChildren<Animator>(true);
        // TryGetComponent<MeleeAttackSystem>(out _ma);

        VisualRoot = transform.Find("Visual");
    }

    private void Start()
    {
        _hs.SetMaxHealth(maxHealth);
        _hs.SetHealth(starterHealth);
        currentHealth = _hs.GetCurrentHealth();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _movementInput = Vector2.zero;
        }
        else
        {
            _movementInput = context.ReadValue<Vector2>();
        }
    }

    private void Update()
    {
        //Player movement
        moveDirection = new Vector3(_movementInput.x, _movementInput.y, 0);
        Vector2 movement = _movementInput;

        if (movement.sqrMagnitude > 1f)
        {
            movement.Normalize();
        }

        if (movement.x != 0)
        {
            _sr.flipX = movement.x < 0;
        }

        _mv.MoveHorizontal(movement.x, moveSpeed);

        if (movement.x != 0)
        {
            _anim.SetBool("isRunning", true);
        }
        else
        {
            _anim.SetBool("isRunning", false);
        }

        //Player jump
        if (_actions.Player.Jump.triggered && _isGrounded)
        {
            _mv.Jump(jumpForce);
            _isGrounded = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }
    public void UpdateHealth()
    {
        currentHealth = _hs.GetCurrentHealth();
    }
    private void OnEnable()
    {
        _actions?.Enable();
    }
    private void OnDisable()
    {
        _actions?.Disable();
    }
    public InventorySystem GetPlayerInventory()
    {
        return _inventory;
    }
}
