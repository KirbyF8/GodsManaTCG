using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecksPrefabs : MonoBehaviour
{

    [SerializeField] TMP_Text deckNameText;

   public void updateInfo(string deckName)
    {
        deckNameText.text = deckName;
    }

    
}
