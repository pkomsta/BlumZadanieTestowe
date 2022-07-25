using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashroomAnimator : MonoBehaviour
{
   
    private Animator anim;
    private MushroomController enemy;
    private float lockedTill;

    private int currentState;

    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Damaged = Animator.StringToHash("Damaged");
    private static readonly int Death = Animator.StringToHash("Death");

    private void Awake()
    {
        enemy = GetComponent<MushroomController>();
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
        if (enemy.CurrentState == enemy.mushroomMoveState)
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


        return Idle;


    }


}




