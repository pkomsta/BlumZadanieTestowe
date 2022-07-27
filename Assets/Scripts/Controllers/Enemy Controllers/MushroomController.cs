using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Waypoints))]
public class MushroomController : Controller
{

    [HideInInspector] public Waypoints waypoints;
    public override BaseState IdleState => new MushroomIdleState();
    public readonly MushroomMoveState mushroomMoveState = new MushroomMoveState();
    public readonly TookDamageState tookDamageState = new TookDamageState();
    public readonly DeathState deathState = new DeathState();
    public readonly MushroomBouncyState mushroomBouncyState = new MushroomBouncyState();
    [HideInInspector] public bool looksRight = true;

    public override void Awake()
    {
        base.Awake();
        waypoints = GetComponent<Waypoints>();
    }
    public override void Update()
    {

        base.Update();
        if (!waypoints.areThereAnyWaypoints()) return;

        if (!waypoints.waypointIsToRight() && looksRight)
        {
            looksRight = false;
            Flip();
        }
        else if (waypoints.waypointIsToRight() && !looksRight)
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
