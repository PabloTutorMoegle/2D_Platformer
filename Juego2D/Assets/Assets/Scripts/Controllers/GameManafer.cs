
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private float startingLives = 3;
    [SerializeField] private float currentLives;
    [SerializeField] private float totalScore;
    public GameObject playerPrefab;

    public float CurrentLives => currentLives;
    public float TotalScore => totalScore;

    private void Awake()
    {
        playerPrefab = TryGetComponent<GameObject>(out playerPrefab) ? playerPrefab : null;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        currentLives = startingLives;
        totalScore = 0;
    }

    public void AddScore(float score)
    {
        totalScore += score;
    }
    public void UpdateLives(float lives)
    {
        currentLives = Mathf.Clamp(currentLives + lives, 0, startingLives);
    }
}
