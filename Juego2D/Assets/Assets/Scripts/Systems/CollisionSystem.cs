using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System;
public class CollisionSystem : MonoBehaviour
{
    public UnityEvent<GameObject> OnCollide;
    public UnityEvent<GameObject> OnTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollide.Invoke(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTrigger.Invoke(other.gameObject);
    }

}
