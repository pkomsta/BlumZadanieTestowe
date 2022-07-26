using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinChaseState : BaseState
{
    public override void EnterState(Controller controller)
    {
        (controller as GoblinController).isChasing = true;
    }

    public override void FixedUpdate(Controller controller)
    {
        if((controller as GoblinController).player != null)
        controller.transform.position = Vector2.MoveTowards(controller.transform.position, (controller as GoblinController).player.transform.position, (controller as GoblinController).chaseSpeed * Time.deltaTime);
    }

    public override void Update(Controller controller)
    {
        if((controller as GoblinController).player != null) {
            if (controller.transform.position.x > (controller as GoblinController).player.transform.position.x && (controller as GoblinController).looksRight)
            {
                (controller as GoblinController).looksRight = false;
                controller.Flip();
                Debug.Log((controller as GoblinController).looksRight);
            }
            else if (controller.transform.position.x < (controller as GoblinController).player.transform.position.x && !(controller as GoblinController).looksRight)
            {
                (controller as GoblinController).looksRight = true;
                controller.Flip();
                Debug.Log((controller as GoblinController).looksRight);
            }

            if (Vector2.Distance(controller.transform.position, (controller as GoblinController).player.transform.position) > (controller as GoblinController).chaseRange)
            {
                controller.TransitionToState((controller as GoblinController).IdleState);
            }
            else if (Vector2.Distance(controller.transform.position, (controller as GoblinController).player.transform.position) < (controller as GoblinController).attackRange)
            {
                controller.TransitionToState((controller as GoblinController).goblinAttackState);
            }
        }
        

        

        
    }
}
