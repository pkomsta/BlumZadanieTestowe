using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBouncyState : BaseState
{
    float stateLength = 0.6f;
    float stateTime = -1;
    public override void EnterState(Controller controller)
    {
        stateTime = Time.time;
    }

    public override void FixedUpdate(Controller controller)
    {
        
    }

    public override void Update(Controller controller)
    {
        if (Time.time > stateTime + stateLength)
        {
            controller.TransitionToState(controller.IdleState);
        }
    }
}
