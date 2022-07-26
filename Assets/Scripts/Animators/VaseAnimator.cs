using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class VaseAnimator : MonoBehaviour
{
    private Animator anim;
    private VaseControler vase;
    private float lockedTill;

    private int currentState;

    private static readonly int Death = Animator.StringToHash("Death");
    private static readonly int Idle = Animator.StringToHash("Idle");
    

    private void Awake()
    {
        vase = GetComponent<VaseControler>();
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

        if (vase.CurrentState == vase.IdleState)
        {
            return Idle;
        }
        if (vase.CurrentState == vase.deathState)
        {
            return Death;
        }


        return Idle;


    }


}



