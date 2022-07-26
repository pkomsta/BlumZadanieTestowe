using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : BaseState
{
    public override void EnterState(Controller controller)
    {
        (controller as GoblinController).arriveTime = Time.time;
        controller.Rigidbody.velocity = new Vector2(0f, 0f);
        (controller as GoblinController).isChasing = false;
    }

    public override void FixedUpdate(Controller controller)
    {
        
    }

    public override void Update(Controller controller)
    {
        if((controller as GoblinController).player != null)
        {
            if (Vector2.Distance(controller.transform.position, (controller as GoblinController).player.transform.position) < (controller as GoblinController).chaseRange)
            {
                controller.TransitionToState((controller as GoblinController).goblinChaseState);
            }
        }
        
        if ((controller as GoblinController).waypoints.Length > 0 && Time.time > (controller as GoblinController).arriveTime + (controller as GoblinController).waitTime)
        {
            controller.TransitionToState((controller as GoblinController).goblinWalkState);
        }
    }
}
