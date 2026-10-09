using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class MovementSystem : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    private Rigidbody2D _rb = null;

    public void Awake()
    {
        TryGetComponent<Rigidbody2D>(out _rb);
    }
    //MoveRb
    public void Move()
    {
        if (_rb != null && direction != null)
        {
            _rb.AddForce(transform.rotation * direction * speed);
        }
    }
    public void Move(Vector3 direc)
    {
        if (_rb != null)
        {
            direction = direc;
            _rb.AddForce(transform.rotation * direction * speed);
        }
    }

    public void Move(Vector3 direc, float s)
    {
        if (_rb != null)
        {
            direction = direc;
            speed = s;
            _rb.AddForce(direction * speed);
        }
    }
    public void MoveLinearVelocity(Vector3 direc, float s)
    {
        direction = direc;
        speed = s;
        if (_rb != null && direction != null)
        {
            _rb.linearVelocity = direction * speed;
        }
    }
    public void Jump(float speed)
    {
        if (_rb != null)
        {
            _rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }
    public void ChangePosition(Vector2 direc)
    {
        this.transform.position = direc;
    }

    public void StopMovement()
    {
        if (_rb != null)
        {
            _rb.linearVelocity = new Vector2(0, 0);
            _rb.angularVelocity = 0;
        }
    }
    public void PauseMovement()
    {
        if (_rb != null)
        {
            _rb.Sleep();
        }
    }
    public void UnPauseMovement()
    {
        if (_rb != null && _rb.IsSleeping())
        {
            _rb.WakeUp();
        }
    }

    public void setDirection(Vector3 d)
    {
        direction = d;
    }
    public float getSpeed()
    {
        return speed;
    }
    public void setSpeed(float s)
    {
        speed = s;
    }
    public void addSpeed(float s)
    {
        speed = speed + s;
    }
    public void multiplySpeed(float s)
    {
        speed = speed * s;
    }
}
