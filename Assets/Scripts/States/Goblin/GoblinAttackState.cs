using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAttackState : BaseState
{
    float attackLength = 0.5f;
    float attackTime = -1;

    public override void EnterState(Controller controller)
    {
        attackTime = Time.time;
    }

    public override void FixedUpdate(Controller controller)
    {
        
    }

    public override void Update(Controller controller)
    {
        if (Time.time > attackTime + attackLength)
        {
            controller.TransitionToState((controller as GoblinController).IdleState);
        }
    }
}
