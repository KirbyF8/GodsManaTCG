using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DecksPrefabs : MonoBehaviour
{

    [SerializeField] TMP_Text deckNameText;

    private DeckCreator creator;

   public void updateInfo(string deckName)
    {
        deckNameText.text = deckName;
    }

    public void loadDeck()
    {

    }
}
