using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    public float jumpForce = 10f;
    

    [HideInInspector] public PlayerInputActions playerControls;
    [Header("Jump")]
    public float jumpInputTime = 0.2f;
    [HideInInspector] public float jumpTime = Mathf.Infinity;
    [HideInInspector] public float timeLeftGrounded = -10;
    [Header("Dash")]
    public float dashCooldown = 2f;
    public float dashSpeed = 20f;
    public float nextDash =0.0f;
    [Header("Attack")]
    public float attackCooldown = 0.5f;
    public float nextAttack = 0.0f;
    [Header("Ground")]
    [SerializeField] private LayerMask terrainMask;
    [SerializeField] private Transform groundCheck;

    const float groundedRadius = .2f;
    private bool grounded;

    public InputAction move
    {
        get;
        private set;
    }
    public InputAction jump
    {
        get;
        private set;
    }
    public InputAction dash
    {
        get;
        private set;
    }
    public InputAction attack
    {
        get;
        private set;
    }


    public override BaseState IdleState => new PlayerIdleState();
    public readonly PlayerMoveState playerMoveState = new PlayerMoveState();
    public readonly PlayerJumpState playerJumpState = new PlayerJumpState();
    public readonly PlayerFallingState playerFallingState = new PlayerFallingState();
    public readonly PlayerDashState playerDashState = new PlayerDashState();
    public readonly PlayerAttackState playerAttackState = new PlayerAttackState();
    public readonly TookDamageState tookDamageState = new TookDamageState();
    public readonly DeathState playerDeathState = new DeathState();


    public override void Awake()
    {
        playerControls = new PlayerInputActions();
        base.Awake();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        jump = playerControls.Player.Jump;
        dash = playerControls.Player.Dash;
        attack = playerControls.Player.Fire;
        move.Enable();
        jump.Enable();
        dash.Enable();
        attack.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        dash.Disable();
        attack.Disable();
    }

    public override void Update()
    {
       
        base.Update();
        if (move.ReadValue<Vector2>().x > 0 && !facingRight)
        {
            
            Flip();
        }
        
        else if (move.ReadValue<Vector2>().x < 0 && facingRight)
        {
            
            Flip();
        }
    }
    public override void FixedUpdate()
    {
        Grounded();
        base.FixedUpdate();
    }
    public void Grounded()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, terrainMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;

            }

        }
        if (!grounded && wasGrounded)
        {
            timeLeftGrounded = Time.time;
        }
    }

    public bool isGrounded()
    {
        return grounded;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundedRadius);
    }

    public override void OnDeath()
    {
        TransitionToState(playerDeathState);
        GameManager.Instance.GameOver();
    }

    public override void TookDamage(Transform transform)
    {
        base.TookDamage(transform);
        TransitionToState(tookDamageState);
        GameManager.Instance.GetHeartAndPopIt();
    }

}
