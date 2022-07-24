using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
    public float jumpForce = 10f;
    public float speed = 10f;
    public PlayerInputActions playerControls;
    public float jumpInputTime = 0.2f;
    [HideInInspector] public float jumpTime = Mathf.Infinity;
    [HideInInspector] public float timeLeftGrounded = -10;
    public float dashCooldown = 2f;
    public float dashSpeed = 75000f;
    public float nextDash =0.0f;

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

    public override BaseState IdleState => new PlayerIdleState();
    public readonly PlayerMoveState playerMoveState = new PlayerMoveState();
    public readonly PlayerJumpState playerJumpState = new PlayerJumpState();
    public readonly PlayerFallingState playerFallingState = new PlayerFallingState();
    public readonly PlayerDashState playerDashState = new PlayerDashState();


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
        move.Enable();
        jump.Enable();
        dash.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
        dash.Disable();
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




}
