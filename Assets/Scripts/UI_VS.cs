using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_VS : MonoBehaviour
{
    [SerializeField] GameObject uiPanel;
    [SerializeField] GameObject pausePanel;
    
    public void HideUIpanel()
    {
        uiPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pausePanel.SetActive(!pausePanel.activeInHierarchy);
        }
    }

    public void Surrender()
    {
        SceneManager.LoadScene(0);
    }
}
