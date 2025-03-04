using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panelSinglePlayer;
    [SerializeField] GameObject panelMultiPlayer;
    [SerializeField] GameObject panelOptions;
    [SerializeField] GameObject panelHistoryMode;
    [SerializeField] GameObject panelRules;
    [SerializeField] GameObject panelPrologue;
    [SerializeField] GameObject panelLevelLocked;

    [SerializeField] GameObject Lock1;
    [SerializeField] GameObject Lock2;
    public void ReturnToMainMenu()
    {
        panelSinglePlayer.SetActive(false);
        panelMultiPlayer.SetActive(false);
        panelOptions.SetActive(false);
        panelHistoryMode.SetActive(false);
        panelRules.SetActive(false);
        panelPrologue.SetActive(false);
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
        panelRules.SetActive(true);
    }

    public void GoToOptions()
    {
        panelOptions.SetActive(true);
    }

    public void GoToLvl1()
    {

        
        PlayerPrefs.SetString("lvl", "DeckIaYumi");
        SceneManager.LoadScene(3);
    }
    public void GoToLvl2()
    {


        PlayerPrefs.SetString("lvl", "DeckIaNumberOne");
        SceneManager.LoadScene(3);
    }
    public void GoToLvl3()
    {


        PlayerPrefs.SetString("lvl", "DeckIaValette");
        SceneManager.LoadScene(3);
    }
    public void GoToPrologue()
    {
        SceneManager.LoadScene(4);
    }

    public void WantPrologue()
    {
        panelPrologue.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
    [SerializeField] private Toggle toggle;
    public void FullScreen()
    {
        Screen.fullScreen = toggle.isOn;
    }

    public void LockedLevel()
    {
        panelLevelLocked.SetActive(true);
    }

    public void HideLockedLevel()
    {
        panelLevelLocked.SetActive(false);
    }

    public void HideLocks()
    {
        //! Only for betatesting
        Lock1.SetActive(false);
        Lock2.SetActive(false);
    }
}
