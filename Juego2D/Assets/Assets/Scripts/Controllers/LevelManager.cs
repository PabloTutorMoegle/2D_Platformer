using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private Button firstSelectedButton;

    public int _totalCoins;
    private int _collectedCoins;
    private bool _levelCompleted = false;

    public int TotalCoins => _totalCoins;
    public int CollectedCoins => _collectedCoins;

    private void Start()
    {
        _collectedCoins = 0;
        if (firstSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(
                firstSelectedButton.gameObject
            );
        }
    }
    public void CollectCoin()
    {
        if (_levelCompleted)
            return;

        _collectedCoins++;

        if (_collectedCoins >= _totalCoins && _totalCoins > 0)
        {
            CompleteLevel();
        }
    }
    private void CompleteLevel()
    {
        if (_levelCompleted)
            return;

        _levelCompleted = true;

        StartCoroutine(FadeAndLoadScene(nextSceneName));
    }
    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);

        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;

        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            color.a = Mathf.Clamp01(elapsed / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;

        LoadNextLevel();
    }
    private void LoadNextLevel()
    {
        if (!string.IsNullOrWhiteSpace(nextSceneName))
        {
            if (Application.CanStreamedLevelBeLoaded(nextSceneName))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.Log("No hay escena");
            }

            return;
        }

        int nextBuildIndex =
            SceneManager.GetActiveScene().buildIndex + 1;

        if (nextBuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextBuildIndex);
        }
        else
        {
            Debug.Log("GG");
        }
    }
    public void NextLevel()
    {
        StartCoroutine(FadeAndLoadScene(nextSceneName));
    }
    public void SetTotalCoins(int totalCoins)
    {
        _totalCoins = totalCoins;
        _collectedCoins = 0;
    }
}
