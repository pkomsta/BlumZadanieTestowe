using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : BaseState
{
    bool dashing;
    float startTime;
    float timeLenght = 0.15f;
    public override void EnterState(Controller controller)
    {
        startTime = Time.time;
        dashing = true;
        controller.Rigidbody.gravityScale = 0f;
    }

    public override void FixedUpdate(Controller controller)
    {
        if (dashing)
        {
            controller.Rigidbody.velocity = SwapToV2(controller.transform.localScale) * (controller as PlayerController).dashSpeed;
        }
    }

    public override void Update(Controller controller)
    {
        
            if (Time.time >= startTime + timeLenght)
            {
                dashing = false;

                controller.TransitionToState((controller as PlayerController).playerFallingState);

            }
        
 
    }

    Vector2 SwapToV2(Vector3 vector)
    {
        return new Vector2(vector.x, 0f);
    }
    
        
}
