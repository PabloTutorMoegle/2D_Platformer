using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Video;
using Unity.VisualScripting;
using System;

public class SceneChangeSystem : MonoBehaviour
{
    public static event Action<int> GameOverDisplay = delegate { };

    [SerializeField] private string sceneName; // Nombre de la escena a cargar (debe estar en Build Settings)

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}