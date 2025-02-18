using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DecksPrefabs : MonoBehaviour
{

    [SerializeField] TMP_Text deckNameText;

    private string localDeckName;

    private DeckCreator creator;
    private void Start()
    {
        creator = FindAnyObjectByType<DeckCreator>();
    }
    public void updateInfo(string deckName)
    {
        deckNameText.text = deckName;
        localDeckName = deckName+".json";
    }

    public void loadDeck()
    {
        creator.DeckLoad(localDeckName);
    }
}
