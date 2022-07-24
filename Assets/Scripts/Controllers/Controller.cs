using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{

    protected bool facingRight = true;
    

    private Rigidbody2D rbody;

    private BaseState currentState;

    public BaseState CurrentState
    {
        get { return currentState; }
    }
    public Rigidbody2D Rigidbody
    {
        get { return rbody; }
    }

    public abstract BaseState IdleState
    {
        get;
    }


    public virtual void Awake()
    { 
        rbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        TransitionToState(IdleState);
    }
    


    public virtual void Update()
    {
        currentState.Update(this);
        Debug.Log(currentState);
    }

    public virtual void FixedUpdate()
    {
        
        currentState.FixedUpdate(this);
    }

    public void TransitionToState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void Flip()
    {
        facingRight = !facingRight;

        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
