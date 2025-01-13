using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panelSinglePlayer;
    [SerializeField] GameObject panelMultiPlayer;
    [SerializeField] GameObject panelOptions;
    [SerializeField] GameObject panelHistoryMode;

    public void ReturnToMainMenu()
    {
        panelSinglePlayer.SetActive(false);
        panelMultiPlayer.SetActive(false);
        panelOptions.SetActive(false);
        panelHistoryMode.SetActive(false);
    }

    public void GoToVSAI()
    {

    }

    public void ReturnToSinglePlayer()
    {
        panelHistoryMode.SetActive(false );
        panelSinglePlayer.SetActive(true);
    }

    public void GoToSinglePlayer()
    {
        panelSinglePlayer.SetActive(true);
    }
    
    public void GoToHistoryMode()
    {
        panelHistoryMode.SetActive(true);
    }

    public void GoToShop()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMultiplayer()
    {
        panelMultiPlayer.SetActive(true);
    }
    public void GoToDeckCreator()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToRules()
    {

    }

    public void GoToOptions()
    {
        panelOptions.SetActive(true);
    }

    public void GoToLvl1()
    {

        //? --- Preparar decks ----
        SceneManager.LoadScene(3);
    }
}
