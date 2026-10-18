using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PointsSystem : MonoBehaviour
{
    private float _points = 0;

    public event Action<float> OnPointsChanged;

    private void Start()
    {
        OnPointsChanged?.Invoke(_points);
    }

    public float GetPoints()
    {
        return _points;
    }

    public void AddPoints(float points)
    {
        if (points <= 0) return;

        _points += points;

        OnPointsChanged?.Invoke(_points);
    }
}
