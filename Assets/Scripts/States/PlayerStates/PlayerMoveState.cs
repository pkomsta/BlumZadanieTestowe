using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : BaseState
{
    bool isMoving;
    Vector2 moveDirection;
    
    public override void EnterState(Controller controller)
    {
        isMoving = true;
    }

    public override void FixedUpdate(Controller controller)
    {
        
        controller.Rigidbody.velocity = new Vector2(moveDirection.x * (controller as PlayerController).speed, controller.Rigidbody.velocity.y);
    }

    public override void Update(Controller controller)
    {
        
        moveDirection = (controller as PlayerController).move.ReadValue<Vector2>();
        if(moveDirection.x == 0)
        {
            controller.TransitionToState((controller as PlayerController).IdleState);
        }
        else if ((controller as PlayerController).jump.WasPressedThisFrame())
        {
            (controller as PlayerController).jumpTime = Time.time;
            controller.TransitionToState((controller as PlayerController).playerJumpState);
            
        }else if (!(controller as PlayerController).grounded.isGrounded() && controller.Rigidbody.velocity.y < -0.1)
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
