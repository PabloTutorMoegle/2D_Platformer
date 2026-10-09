using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D _rb;

    private void Awake()
    {
        TryGetComponent<Rigidbody2D>(out _rb);
    }

    public void Jump()
    {
        if (_rb != null)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
