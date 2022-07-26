using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWalkState : BaseState
{
    public override void EnterState(Controller controller)
    {
        (controller as GoblinController).arriveTime = Time.time;
    }

    public override void FixedUpdate(Controller controller)
    {
        controller.transform.position = Vector2.MoveTowards(controller.transform.position, (controller as GoblinController).waypoints[(controller as GoblinController).waypointIndex].transform.position, controller.speed * Time.deltaTime);
    }

    public override void Update(Controller controller)
    {
        Move(controller as GoblinController);
    }
    void Move(GoblinController controller)
    {

        if (Vector2.Distance(controller.transform.position, (controller as GoblinController).player.transform.position) < (controller as GoblinController).chaseRange)
        {
            controller.TransitionToState((controller as GoblinController).goblinChaseState);
        }
        if (Vector2.Distance(controller.transform.position, controller.waypoints[controller.waypointIndex].transform.position) < 0.5f)
        {
            controller.waypointIndex++;
            if (controller.waypointIndex == controller.waypoints.Length)
            {
                controller.waypointIndex = 0;
            }
            controller.TransitionToState(controller.IdleState);
        }


    }
}
