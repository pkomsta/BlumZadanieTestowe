using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TookDamageState : BaseState
{
    float timeDamage;
    float stateDuration = 0.35f;
    public override void EnterState(Controller controller)
    {
        timeDamage = Time.time;
    }

    public override void FixedUpdate(Controller controller)
    {
        
    }

    public override void Update(Controller controller)
    {
        if(Time.time > timeDamage + stateDuration)
        {
            controller.TransitionToState(controller.IdleState);
        }
    }
}
