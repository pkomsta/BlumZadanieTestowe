using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Waypoints))]
public class GoblinController : Controller
{

    public float chaseRange = 10f;
    public float attackRange = 1f;
    [HideInInspector] public GameObject player;
    public float chaseSpeed = 5f;

    [HideInInspector] public bool isChasing = false;
    [HideInInspector] public bool looksRight = true;
    [HideInInspector] public Waypoints waypoints;
    public override BaseState IdleState => new GoblinIdleState();
    public readonly TookDamageState tookDamageState = new TookDamageState();
    public readonly DeathState deathState = new DeathState();
    public readonly GoblinWalkState goblinWalkState = new GoblinWalkState();
    public readonly GoblinChaseState goblinChaseState = new GoblinChaseState();
    public readonly GoblinAttackState goblinAttackState = new GoblinAttackState();

    public override void Awake()
    {
        base.Awake();
        player = GameObject.FindWithTag("Player");
        waypoints = GetComponent<Waypoints>();
    }
    public override void Update()
    {

        base.Update();
        if (!waypoints.areThereAnyWaypoints()) return;
        if (isChasing) return;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
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
