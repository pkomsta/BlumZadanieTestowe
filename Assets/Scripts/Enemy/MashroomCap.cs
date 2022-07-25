using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MashroomCap : MonoBehaviour
{
    [SerializeField] MushroomController mushroom;
    [SerializeField] float capBouncines = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * capBouncines, ForceMode2D.Impulse);
            mushroom.TransitionToState(mushroom.mushroomBouncyState);
        }
    }
    

}
