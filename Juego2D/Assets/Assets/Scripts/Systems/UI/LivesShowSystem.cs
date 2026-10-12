using UnityEngine;
using System.Collections.Generic;

public class LivesShowSystem : MonoBehaviour
{
    public GameObject livesUI;
    public PlayerController player;

    private void LateUpdate()
    {
        SetUp();
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

        // If there are more UI elements than total lives, disable the extra ones
        for (int i = totalLives; i < livesUI.transform.childCount; i++)
        {
            livesUI.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
