using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public float damageAmount = 1.0f;

    public void DoDamage(GameObject gameObject){
        if (gameObject.TryGetComponent<HealthSystem>(out HealthSystem hs))
            hs.Hurt(damageAmount);
    }

}