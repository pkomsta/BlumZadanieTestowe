using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    [Header("Ground")]
    [SerializeField] private LayerMask terrainMask;
    [SerializeField] private Transform groundCheck;

    const float groundedRadius = .2f;
    bool grounded;
    [HideInInspector] public float timeLeftGrounded;

    private void FixedUpdate()
    {
        CheckGrounded();
    }
    public void CheckGrounded()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, terrainMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                grounded = true;

            }

        }
        if (!grounded && wasGrounded)
        {
            timeLeftGrounded = Time.time;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundedRadius);
    }

    public bool isGrounded()
    {
        return grounded;
    }
}

