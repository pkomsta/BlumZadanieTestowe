using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    Animator animator;
    [HideInInspector] public bool wasDestroyed = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    public void DestroyHeart()
    {
        animator.enabled = true;
        wasDestroyed = true;
    }

    //Odpalane przez event w animacji serca;
    public void TurnAnimatorOff()
    {
        GetComponent<Image>().enabled = false;
    }
}
