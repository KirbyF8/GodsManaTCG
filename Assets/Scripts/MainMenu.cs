using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panelSinglePlayer;
    [SerializeField] GameObject panelMultiPlayer;
    [SerializeField] GameObject panelOptions;

    public void ReturnToMainMenu()
    {
        panelSinglePlayer.SetActive(false);
        panelMultiPlayer.SetActive(false);
        panelOptions.SetActive(false);
    }

    public void GoToSinglePlayer()
    {
        panelSinglePlayer.SetActive(true);
    }
    
    public void GoToHistoryMode()
    {

    }

    public void GoToVsIA()
    {

    }
    public void GoToShop()
    {

    }

    public void GoToMultiplayer()
    {
        panelMultiPlayer.SetActive(true);
    }
    public void GoToDeckCreator()
    {

    }

    public void GoToRules()
    {

    }

    public void GoToOptions()
    {
        panelOptions.SetActive(true);
    }
}
