using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_VS : MonoBehaviour
{
    [SerializeField] GameObject uiPanel;
    
    public void HideUIpanel()
    {
        uiPanel.SetActive(false);
    }


}
