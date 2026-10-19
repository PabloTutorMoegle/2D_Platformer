using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject howToPlayMenu;

    public void Awake()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        howToPlayMenu.SetActive(false);
    }
    public void ShowOptionsMenu()
    {
        optionsMenu.SetActive(true);
        howToPlayMenu.SetActive(false);
        mainMenu.SetActive(false);
    }
    public void ShowHowToPlayMenu()
    {
        optionsMenu.SetActive(false);
        howToPlayMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void HideMenus()
    {
        optionsMenu.SetActive(false);
        howToPlayMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
