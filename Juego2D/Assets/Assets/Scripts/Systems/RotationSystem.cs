using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSystem : MonoBehaviour
{
    public float turnspeed;
    private Rigidbody2D _rb;
    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Turn(float rotation)
    {
        Debug.Log("Rotation: " + rotation);
        transform.Rotate(0,0,rotation*turnspeed);       
    }
    public void SetRandomRotation2D()
    { 
        transform.eulerAngles = new Vector3(0.0f, 0.0f, UnityEngine.Random.value * 360.0f);
    }
    public void AddTorquetoGO()
    {
        if (_rb != null) _rb.AddTorque(20f); 
    }
}
