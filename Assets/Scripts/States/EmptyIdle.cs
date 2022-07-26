using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyIdle : BaseState
{
    public override void EnterState(Controller controller)
    {
        controller.Rigidbody.velocity = new Vector2(0f, 0f);
    }

    public override void FixedUpdate(Controller controller)
    {
       
    }

    public override void Update(Controller controller)
    {
        
    }
}
