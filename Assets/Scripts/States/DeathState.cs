using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : BaseState
{
    float timeBeforeDestroy = 0.5f;
    float timeOfDeath;
    public override void EnterState(Controller controller)
    {
        timeOfDeath = Time.time;
        controller.GetComponent<Collider2D>().enabled = false;

    }

    public override void FixedUpdate(Controller controller)
    {
        
    }

    public override void Update(Controller controller)
    {
        if(Time.time > timeOfDeath + timeBeforeDestroy)
        {
            GameManager.Instance.DestroyOnDeath(controller.gameObject);
        }
    }
}
