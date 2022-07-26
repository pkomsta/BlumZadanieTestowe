using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : Controller
{
    public Transform[] waypoints;
    public float waitTime = 1f;
    public float arriveTime = Mathf.Infinity;
    [HideInInspector] public int waypointIndex;
    public override BaseState IdleState => new MushroomIdleState();
    public readonly MushroomMoveState mushroomMoveState = new MushroomMoveState();
    public readonly TookDamageState tookDamageState = new TookDamageState();
    public readonly DeathState deathState = new DeathState();
    public readonly MushroomBouncyState mushroomBouncyState = new MushroomBouncyState();
    bool looksRight = true;
    public override void Update()
    {

        base.Update();
        if (waypoints.Length <= 0) return;
        if (waypoints[waypointIndex].transform.position.x < transform.position.x && looksRight)
        {
            looksRight = false;
            Flip();
        }
        else if (waypoints[waypointIndex].transform.position.x > transform.position.x && !looksRight)
        {
            looksRight = true;
            Flip();
        }
    }
    public override void OnDeath()
    {
        TransitionToState(deathState);
    }

    public override void TookDamage(Transform transform)
    {
        base.TookDamage(transform);
        TransitionToState(tookDamageState);
    }
}
