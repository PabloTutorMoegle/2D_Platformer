using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PointsSystem : MonoBehaviour
{
    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    public void AddPoints(int points)
    {
        if (points <= 0)
            return;

        _score += points;

        OnScoreChanged?.Invoke(_score);
    }

    public event Action<int> OnScoreChanged;
}
    // public UnityEvent<string> ScoreTextChange;
    // public UnityEvent<string> MultTextChange;
    // public float mult;
    // public float multpoints = 0;
    // //ComboSystem
    // private int currentscore;

    // private void SumPoints(int points){
    //     multpoints = points * mult;
    //     currentscore += points; //currentscore += points + multpoints;
    //     string u = $"SCORE: {currentscore}";
    //     string m = $"x{mult + 1}";//
    //     ScoreTextChange.Invoke(u);
    //     MultTextChange.Invoke(m);//

    //      int maxScore = PlayerPrefs.GetInt("MaxScore", 0);  // Recuperar puntuación máxima guardada
    //     if (currentscore > maxScore)
    //     {
    //         PlayerPrefs.SetInt("MaxScore", currentscore);  // Guardar nueva puntuación máxima
    //         PlayerPrefs.Save();  // Guardar los cambios inmediatamente
    //     }
    // }
    // public void SetMult(float m) {
    //     mult = m;
    // }

    // //public int getCurrentscore()
    // public int getCurrentscore() 
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
