using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMoveState : BaseState
{
    public override void EnterState(Controller controller)
    {
        (controller as MushroomController).waypoints.arriveTime = Time.time;
    }

    public override void FixedUpdate(Controller controller)
    {
        controller.transform.position = Vector2.MoveTowards(controller.transform.position, (controller as MushroomController).waypoints.waypoints[(controller as MushroomController).waypoints.waypointIndex].transform.position, controller.speed * Time.deltaTime);
    }

    public override void Update(Controller controller)
    {

        (controller as MushroomController).waypoints.CheckIfArrived((controller as MushroomController));
    }

}
