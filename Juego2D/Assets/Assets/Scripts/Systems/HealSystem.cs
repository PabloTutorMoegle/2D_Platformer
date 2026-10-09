using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSystem : MonoBehaviour
{
    public float healAmount = 1.0f;

    public void DoHeal(GameObject gameObject){
        if (gameObject.TryGetComponent<HealthSystem>(out HealthSystem hs))
            hs.Heal(healAmount);
    }

}