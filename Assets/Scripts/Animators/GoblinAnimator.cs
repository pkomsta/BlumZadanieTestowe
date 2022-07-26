using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnimator : MonoBehaviour
{
    private Animator anim;
    private GoblinController enemy;
    private float lockedTill;

    private int currentState;

    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Damaged = Animator.StringToHash("Damaged");
    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Attack = Animator.StringToHash("Attack");


    private void Awake()
    {
        enemy = GetComponent<GoblinController>();
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

        if (enemy.CurrentState == enemy.IdleState)
        {
            return Idle;
        }
        if (enemy.CurrentState == enemy.goblinWalkState)
        {
            return Walk;
        }
        if (enemy.CurrentState == enemy.goblinChaseState)
        {
            return Walk;
        }
        if (enemy.CurrentState == enemy.tookDamageState)
        {
            return Damaged;
        }
        if (enemy.CurrentState == enemy.deathState)
        {
            return Death;
        }
        if (enemy.CurrentState == enemy.goblinAttackState)
        {
            return Attack;
        }



        return Idle;


    }
}
