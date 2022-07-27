using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : BaseState
{
    bool jumped = false;
    Vector2 moveDirection;
    float timeFalling = -10;
    public override void EnterState(Controller controller)
    {
        jumped = false;
        controller.Rigidbody.gravityScale = 3f;
       
    }

    public override void FixedUpdate(Controller controller)
    {
        controller.Rigidbody.velocity = new Vector2(moveDirection.x * (controller as PlayerController).speed / 2, controller.Rigidbody.velocity.y);
    }

    public override void Update(Controller controller)
    {
        timeFalling = Time.time;
        moveDirection = (controller as PlayerController).move.ReadValue<Vector2>();
        
        if ((controller as PlayerController).jump.WasPressedThisFrame())
        {
            if ((Time.time < (controller as PlayerController).timeLeftGrounded + (controller as PlayerController).jumpInputTime))
            {
                controller.TransitionToState((controller as PlayerController).playerJumpState);
            }
            else if ((Time.time < timeFalling + (controller as PlayerController).jumpInputTime) && !jumped)
            {
                jumped = true;
                controller.Rigidbody.velocity = new Vector2(controller.Rigidbody.velocity.x, 0f);
                controller.Rigidbody.AddForce(Vector2.up * (controller as PlayerController).jumpForce, ForceMode2D.Impulse);
            }
        }
       else if (controller.Rigidbody.velocity.y == 0 && (controller as PlayerController).grounded.isGrounded())
        {

            controller.TransitionToState((controller as PlayerController).IdleState);

        }

        if ((controller as PlayerController).dash.WasPressedThisFrame() && Time.time > (controller as PlayerController).nextDash)
        {
            (controller as PlayerController).nextDash = Time.time + (controller as PlayerController).dashCooldown;
            controller.TransitionToState((controller as PlayerController).playerDashState);
        }

    }
}
