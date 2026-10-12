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
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        if (_ps != null)
        {
            _ps.OnScoreChanged += UpdateScore;
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
            _ps.OnScoreChanged -= UpdateScore;
        }
    }

    private void UpdateScore(int score)
    {
        if (_scoreText != null)
        {
            _scoreText.text = $"{score}";
        }
    }
}
