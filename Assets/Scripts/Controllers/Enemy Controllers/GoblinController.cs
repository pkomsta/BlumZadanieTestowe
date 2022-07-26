using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinController : Controller
{
    public Transform[] waypoints;
    public float waitTime = 1f;
    public float arriveTime = Mathf.Infinity;
    [HideInInspector] public int waypointIndex;

    public float chaseRange = 10f;
    public float attackRange = 1f;
    [HideInInspector] public GameObject player;
    public float chaseSpeed = 5f;

    [HideInInspector] public bool isChasing = false;
    [HideInInspector] public bool looksRight = true;
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
    }
    public override void Update()
    {

        base.Update();
        if (waypoints.Length <= 0) return;
        if (isChasing) return;
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
