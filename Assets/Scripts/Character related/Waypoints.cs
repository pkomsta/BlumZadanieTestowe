using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] waypoints;
    public float waitTime = 1f;
    public float arriveTime = Mathf.Infinity;
    [HideInInspector] public int waypointIndex;

    public void CheckIfArrived(Controller controller)
    {
        if (Vector2.Distance(controller.transform.position, waypoints[waypointIndex].transform.position) < 0.5f)
        {
            waypointIndex++;
            if (waypointIndex == waypoints.Length)
            {
                waypointIndex = 0;
            }
            controller.TransitionToState(controller.IdleState);
        }
    }
    public bool areThereAnyWaypoints()
    {
        return waypoints.Length > 0;
    }
    public bool waypointIsToRight()
    {
        return waypoints[waypointIndex].transform.position.x > transform.position.x;
    }
}

