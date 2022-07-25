using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class TookDamageEvent : UnityEvent<Transform>
{
}
public class Health : MonoBehaviour
{
    public int health = 1;
    bool isDead = false;
    public TookDamageEvent tookDamage;
    bool canBeDamaged = true;
    public float invincibleTime = 0.75f;

    public void TakeDamage(Transform transform)
    {
        if (!isDead)
        {
            health--;
        }
        if(health <= 0)
        {
            isDead = true;
        }
        tookDamage?.Invoke(transform);
        canBeDamaged = false;
        StartCoroutine(InvincibleTime());
    }
    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(invincibleTime);
        canBeDamaged = true;
    }
    public bool IsDead()
    {
        return isDead;
    }
}
