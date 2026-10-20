
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float startingLives = 3f;
    [SerializeField] private float currentLives;
    [SerializeField] private float totalScore;
    public string gameOverSceneName;
    private GameObject player;
    public float CurrentLives => currentLives;
    public float TotalScore => totalScore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        currentLives = startingLives;
        totalScore = 0f;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        FindPlayer();
        UpdatePlayerData();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindPlayer();
        UpdatePlayerData();
    }

    private void FindPlayer()
    {
        if (player != null)
            return;

        PlayerController controller =
            FindFirstObjectByType<PlayerController>();

        if (controller != null)
            player = controller.gameObject;
    }

    private void Update()
    {
        UpdatePlayerData();
    }

    private void UpdatePlayerData()
    {
        if (player == null)
            return;

        HealthSystem healthSystem =
            player.GetComponent<HealthSystem>();

        if (healthSystem != null)
            currentLives = healthSystem.GetCurrentHealth();

        PointsSystem pointsSystem =
            player.GetComponent<PointsSystem>();

        if (pointsSystem != null)
            totalScore = pointsSystem.GetPoints();
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Instance = null;
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
