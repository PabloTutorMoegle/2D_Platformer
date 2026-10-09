using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float maxhealth;

    [SerializeField]
    private float health;

    public UnityEvent<float> OnChangeHealHealth;
    public UnityEvent<float> OnChangeHurtHealth;
    public UnityEvent<float> UpdateHearts;

    public UnityEvent OnZeroLifes;

    private void Start()
    {
        health = maxhealth;
    }

    public float GetMaxHealth()
    {
        return maxhealth;
    }

    public float GetCurrentHealth()
    {
        return health;
    }

    public void SetMaxHealth(float maxh)
    {
        maxhealth = maxh;
    }

    public void SetHealth(float h)
    {
        health = h;
    }

    public void Hurt(float damage)
    {
        health -= damage;
        OnChangeHurtHealth.Invoke(health);
        if (health <= 0)
        {
            health = 0;
            OnZeroLifes.Invoke();
        }
    }

    public void Heal(float heal)
    {
        if (health + heal > maxhealth)
        {
            health = maxhealth;
        }
        else
        {
            health += heal;
        }
        OnChangeHealHealth.Invoke(health);
    }
}
