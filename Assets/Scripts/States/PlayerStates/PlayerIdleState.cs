using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : BaseState
{
    public override void EnterState(Controller controller)
    {
        controller.Rigidbody.velocity = new Vector2(0f, 0f);
        controller.Rigidbody.gravityScale = 1.5f;
    }

    public override void FixedUpdate(Controller controller)
    {

    }

    public override void Update(Controller controller)
    {


        if ((controller as PlayerController).move.IsPressed())
        {
            controller.TransitionToState((controller as PlayerController).playerMoveState);
        }

        if ((controller as PlayerController).jump.WasPressedThisFrame())
        {
            (controller as PlayerController).jumpTime = Time.time;
            controller.TransitionToState((controller as PlayerController).playerJumpState);
        }
        else if (!(controller as PlayerController).grounded.isGrounded() && controller.Rigidbody.velocity.y < -0.1)
        {
            controller.TransitionToState((controller as PlayerController).playerFallingState);
        }
        if ((controller as PlayerController).attack.WasPressedThisFrame() && Time.time > (controller as PlayerController).nextAttack)
        {
            (controller as PlayerController).nextAttack = Time.time + (controller as PlayerController).attackCooldown;
            controller.TransitionToState((controller as PlayerController).playerAttackState);
        }

        if ((controller as PlayerController).dash.WasPressedThisFrame() && Time.time > (controller as PlayerController).nextDash )
        {
            (controller as PlayerController).nextDash = Time.time + (controller as PlayerController).dashCooldown;
            controller.TransitionToState((controller as PlayerController).playerDashState);
        }
    }
}
