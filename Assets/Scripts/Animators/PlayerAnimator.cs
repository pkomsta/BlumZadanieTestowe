using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private float _minImpactForce = 20;

    [SerializeField] private float _landAnimDuration = 0.1f;
    [SerializeField] private float _attackAnimTime = 0.2f;

    private Animator _anim;
    private SpriteRenderer renderer;
    private PlayerController player;
    private float lockedTill;

    private int currentState;
    
    private static readonly int Idle = Animator.StringToHash("PlayerIdle");
    private static readonly int Walk = Animator.StringToHash("PlayerRun");
    private static readonly int Jump = Animator.StringToHash("PlayerJump");
    private static readonly int Fall = Animator.StringToHash("PlayerFall");
    private static readonly int Dash = Animator.StringToHash("PlayerDash");
    private static readonly int Attack = Animator.StringToHash("PlayerAttack");

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        _anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {

        var state = GetState();


        if (state == currentState) return;
        _anim.CrossFade(state, 0, 0);
        currentState = state;
    }

    private int GetState()
    {

        if (player.CurrentState == player.IdleState)
        { 
            return Idle;
        }
        if (player.CurrentState == player.playerMoveState)
        {
            return Walk;
        }
        if (player.CurrentState == player.playerJumpState)
        {
            return Jump;
        }
        if (player.CurrentState == player.playerFallingState)
        {
            return Fall;
        }
        if (player.CurrentState == player.playerDashState)
        {
            return Dash;
        }

        return Idle;

        int LockState(int s, float t)
        {
            lockedTill = Time.time + t;
            return s;
        }
    }


}


