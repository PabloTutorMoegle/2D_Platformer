using UnityEngine;
using System.Collections.Generic;

public class LivesShowSystem : MonoBehaviour
{
    public GameObject livesUI;
    public PlayerController player;
    private HealthSystem healthSystem;


    private void Start()
    {
        ConnectToPlayer();
        SetUp();
    }
    private void LateUpdate()
    {
        if (healthSystem == null)
        {
            ConnectToPlayer();
        }

        SetUp();
    }
    private void ConnectToPlayer()
    {
        player = PlayerPersistence.PersistentPlayer;

        if (player == null)
        {
            player = FindFirstObjectByType<PlayerController>();
        }

        if (player != null)
        {
            healthSystem = player.GetComponent<HealthSystem>();
        }
    }
    private void SetUp()
    {
        int currentLives = Mathf.RoundToInt(player.currentHealth);
        int totalLives = Mathf.RoundToInt(player.maxHealth);

        for (int i = 0; i < livesUI.transform.childCount; i++)
        {
            if (i < currentLives)
            {
                livesUI.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                livesUI.transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        for (int i = totalLives; i < livesUI.transform.childCount; i++)
        {
            livesUI.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
