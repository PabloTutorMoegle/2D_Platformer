using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;
using UnityEngine.InputSystem.Controls;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions _actions;
    private MovementSystem _mv;
    private HealthSystem _hs;
    // private Animator _anim;
    private SpriteRenderer _sr;
    // private MeleeAttackSystem _ma;

    // private bool _isAttacking = false;
    // private float attackTimer = 0.3f;
    
    // public GameObject attackHitbox;

    //Health variables
    public float maxHealth = 100;
    public float currentHealth;

    //Movement variables
    public float moveSpeed = 5f;
    public Vector3 moveDirection;
    private Vector2 _movementInput;
    float inputMagnitude = 0f;
    public float jumpForce;
    bool _isGrounded = true;


    private void Awake()
    {
        _actions = new InputSystem_Actions();
        _actions.Player.Move.performed += OnMove;
        TryGetComponent<MovementSystem>(out _mv);
        TryGetComponent<HealthSystem>(out _hs);
        // TryGetComponent<Animator>(out _anim);
        TryGetComponent<SpriteRenderer>(out _sr);
        // TryGetComponent<MeleeAttackSystem>(out _ma);
    }

    private void Start()
    {
        _hs.SetMaxHealth(maxHealth);
        _hs.SetHealth(maxHealth);
        currentHealth = _hs.GetCurrentHealth();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        //Player movement

        moveDirection = new Vector3(_movementInput.x, _movementInput.y, 0);
        inputMagnitude = _movementInput.magnitude;

        Debug.Log(inputMagnitude);

        if (_movementInput.x == 0f)
        {
            _mv.MoveLinearVelocity(Vector3.zero, moveSpeed);
        }
        else
        {
            Vector3 normalizedDir = moveDirection / inputMagnitude;
            _mv.MoveLinearVelocity(normalizedDir, moveSpeed * inputMagnitude);
        }

        //Player jump
        if (_actions.Player.Jump.triggered && _isGrounded)
        {
            _mv.Jump(jumpForce);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

    private void OnEnable()
    {
        if (_actions == null)
        {
            _actions = new InputSystem_Actions();
        }
        _actions.Enable();
    }
    private void OnDisable()
    {
        _actions.Disable();
    }
}
