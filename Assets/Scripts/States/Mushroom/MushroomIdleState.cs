using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomIdleState : BaseState
{

    public override void EnterState(Controller controller)
    {
        (controller as MushroomController).waypoints.arriveTime = Time.time;
        controller.Rigidbody.velocity = new Vector2(0f, 0f);
    }

    public override void FixedUpdate(Controller controller)
    {
        
    }

    public override void Update(Controller controller)
    {
        if((controller as MushroomController).waypoints.areThereAnyWaypoints() && Time.time > (controller as MushroomController).waypoints.arriveTime + (controller as MushroomController).waypoints.waitTime)
        {
            controller.TransitionToState((controller as MushroomController).mushroomMoveState);
        }
    }
}
