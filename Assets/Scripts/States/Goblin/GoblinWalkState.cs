using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWalkState : BaseState
{
    public override void EnterState(Controller controller)
    {
        (controller as GoblinController).waypoints.arriveTime = Time.time;
    }

    public override void FixedUpdate(Controller controller)
    {
        controller.transform.position = Vector2.MoveTowards(controller.transform.position, (controller as GoblinController).waypoints.waypoints[(controller as GoblinController).waypoints.waypointIndex].transform.position, controller.speed * Time.deltaTime);
    }

    public override void Update(Controller controller)
    {
        (controller as GoblinController).waypoints.CheckIfArrived((controller as GoblinController));
    }
    
}
