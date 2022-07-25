using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Transform hitPosition;
    [SerializeField] float attackRange = 1f;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] GameObject attackAnimation;

    private void Start()
    {
       if(attackAnimation != null) attackAnimation.SetActive(false);
    }
    public void DoAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitPosition.position, attackRange, targetLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.TryGetComponent(out Health health)){
                health.TakeDamage(transform);
                
            }
        }
        if(hitEnemies.Length > 0 && attackAnimation != null)
        {
            StartCoroutine(ShowAttackEffect());
        }

    }
    IEnumerator ShowAttackEffect()
    {
        attackAnimation.transform.parent = null;
        attackAnimation.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        attackAnimation.SetActive(false);
        
        attackAnimation.transform.parent = hitPosition;
        attackAnimation.transform.localPosition = Vector3.zero;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(hitPosition.position, attackRange);
        
    }
}
