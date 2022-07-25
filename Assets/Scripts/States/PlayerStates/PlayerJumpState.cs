using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : BaseState
{
    bool isJumping;
    Vector2 moveDirection;
    public override void EnterState(Controller controller)
    {
        
        controller.Rigidbody.gravityScale = 2.5f;
        isJumping = true;
        controller.Rigidbody.AddForce(Vector2.up * (controller as PlayerController).jumpForce,ForceMode2D.Impulse);
        isJumping = false;
   
    }

    public override void FixedUpdate(Controller controller)
    {
        controller.Rigidbody.velocity = new Vector2(moveDirection.x * (controller as PlayerController).speed/2, controller.Rigidbody.velocity.y);
    }

    public override void Update(Controller controller)
    {
        if (isJumping) return;
        moveDirection = (controller as PlayerController).move.ReadValue<Vector2>();
        if (controller.Rigidbody.velocity.y < -0.1)
        {
            controller.TransitionToState((controller as PlayerController).playerFallingState);
        }

        if ((controller as PlayerController).attack.WasPressedThisFrame() && Time.time > (controller as PlayerController).nextAttack)
        {
            (controller as PlayerController).nextAttack = Time.time + (controller as PlayerController).attackCooldown;
            controller.TransitionToState((controller as PlayerController).playerAttackState);
        }

        if ((controller as PlayerController).dash.WasPressedThisFrame() && Time.time > (controller as PlayerController).nextDash)
        {
            (controller as PlayerController).nextDash = Time.time + (controller as PlayerController).dashCooldown;
            controller.TransitionToState((controller as PlayerController).playerDashState);
        }


    }

}
