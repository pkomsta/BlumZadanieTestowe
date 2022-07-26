using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseControler : Controller
{
    [SerializeField] Coin coin;
    public override BaseState IdleState => new EmptyIdle();
    public readonly DeathState deathState = new DeathState();

    public override void OnDeath()
    {
        TransitionToState(deathState);
        Instantiate(coin, transform.position,Quaternion.identity);
    }
}

