using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Controller : MonoBehaviour
{
    public float speed = 10f;
    protected bool facingRight = true;
    Health health;
    bool died = false;

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
    [Header("KnockBack")]
    public float knockback = 500f;

    public virtual void Awake()
    { 
        rbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        health = GetComponent<Health>();
        health.tookDamage.AddListener(TookDamage);
        TransitionToState(IdleState);
    }
    


    public virtual void Update()
    {
        if(health.IsDead() && !died)
        {
            died = true;
            OnDeath();
        }
        currentState.Update(this);
        
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

    public abstract void OnDeath();
    public virtual void TookDamage(Transform transform)
    {
        Vector2 moveDirection = Rigidbody.transform.position - transform.position;
        Rigidbody.AddForce(moveDirection.normalized * knockback);
        Rigidbody.AddForce(Vector2.up * knockback / 2);
    }

}
