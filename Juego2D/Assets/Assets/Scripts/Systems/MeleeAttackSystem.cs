using System;
using System.Collections;
using UnityEngine;

public class MeleeAttackSystem : MonoBehaviour
{
    public void Attack(GameObject attackHitbox, float timer)
    {
        attackHitbox.SetActive(true);
        
        // Deactivate hitbox after timer seconds
        IEnumerator DeactiveAttack()
        {
            yield return new WaitForSeconds(timer);
            attackHitbox.SetActive(false);
        }

        StartCoroutine(DeactiveAttack());
    }
}
