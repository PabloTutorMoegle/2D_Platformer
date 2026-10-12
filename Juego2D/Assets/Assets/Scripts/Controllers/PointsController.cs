using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class PointsController : MonoBehaviour
{
    [SerializeField] private PointsSystem _ps;
    [SerializeField] private TMP_Text _pointsText;

    private void OnEnable()
    {
        if (_ps != null)
        {
            _ps.OnPointsChanged += UpdateScore;
        }
    }

    private void Start()
    {
        if (_ps != null)
        {
            UpdateScore(_ps.GetScore());
        }
    }

    private void OnDisable()
    {
        if (_ps != null)
        {
            _ps.OnPointsChanged -= UpdateScore;
        }
    }

    private void UpdateScore(float points)
    {
        if (_pointsText != null)
        {
            _pointsText.text = $"{points}";
        }
    }
}
