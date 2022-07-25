using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    private PlayerController player;
    private float lockedTill;

    private int currentState;
    
    private static readonly int Idle = Animator.StringToHash("PlayerIdle");
    private static readonly int Walk = Animator.StringToHash("PlayerRun");
    private static readonly int Jump = Animator.StringToHash("PlayerJump");
    private static readonly int Fall = Animator.StringToHash("PlayerFall");
    private static readonly int Dash = Animator.StringToHash("PlayerDash");
    private static readonly int Attack = Animator.StringToHash("PlayerAttack");
    private static readonly int Death = Animator.StringToHash("PlayerDeath");

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        
    }


    private void Update()
    {
        var state = GetState();

        if (state == currentState) return;
        anim.CrossFade(state, 0, 0);
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
        if(player.CurrentState == player.playerAttackState)
        {
            return Attack;
        }
        if (player.CurrentState == player.tookDamageState)
        {
            return Fall;
        }
        if (player.CurrentState == player.playerDeathState)
        {
            return Death;
        }


        return Idle;

        
    }


}


