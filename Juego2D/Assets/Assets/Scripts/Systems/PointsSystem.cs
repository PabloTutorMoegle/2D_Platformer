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
        if (GameManager.Instance != null)
        {
            _points = GameManager.Instance.TotalScore;
        }

        OnPointsChanged?.Invoke(_points);
    }

    public float GetScore()
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

    // public UnityEvent<string> ScoreTextChange;
    // public UnityEvent<string> MultTextChange;
    // public float mult;
    // public float multpoints = 0;
    // //ComboSystem
    // private float currentscore;

    // private void SumPoints(float points){
    //     multpoints = points * mult;
    //     currentscore += points; //currentscore += points + multpoints;
    //     string u = $"SCORE: {currentscore}";
    //     string m = $"x{mult + 1}";//
    //     ScoreTextChange.Invoke(u);
    //     MultTextChange.Invoke(m);//

    //      float maxScore = PlayerPrefs.GetInt("MaxScore", 0);  // Recuperar puntuación máxima guardada
    //     if (currentscore > maxScore)
    //     {
    //         PlayerPrefs.SetInt("MaxScore", currentscore);  // Guardar nueva puntuación máxima
    //         PlayerPrefs.Save();  // Guardar los cambios inmediatamente
    //     }
    // }
    // public void SetMult(float m) {
    //     mult = m;
    // }

    // //public float getCurrentscore()
    // public float getCurrentscore() 
    // { 
    //     return currentscore;
    // }

    // void OnEnable()
    // {
    //     PointsController.OnScoreChange+=SumPoints;
    // }
    
    // void OnDisable()
    // {
    //     PointsController.OnScoreChange-=SumPoints;
    // }
