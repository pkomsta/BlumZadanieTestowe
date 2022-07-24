using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState 
{
    public abstract void EnterState(Controller controller);

    public abstract void Update(Controller controller);

    public abstract void FixedUpdate(Controller controller);
}
