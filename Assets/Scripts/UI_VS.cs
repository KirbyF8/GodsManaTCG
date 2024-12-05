using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_VS : MonoBehaviour
{
    [SerializeField] GameObject Ui_panel;
    
    public void HideUIpanel()
    {
        Ui_panel.SetActive(false);
    }


}
