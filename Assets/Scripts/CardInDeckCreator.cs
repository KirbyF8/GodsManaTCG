using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInDeckCreator : MonoBehaviour
{
    
    [SerializeField] RawImage background;
    [SerializeField] TMP_Text textCardName;
    [SerializeField] TMP_Text textCardCost;


    DeckCreator deckCreator;

    private string localCardName;



    private void Start()
    {
        deckCreator = FindObjectOfType<DeckCreator>();
    }


    
    public void updateInfoCard(string cardName, int cardCost, string cardGod)
    {
        localCardName = cardName;

        textCardName.color = Color.black;
        textCardName.text = cardName;
        textCardCost.text = cardCost.ToString();

        if (cardGod == "Dana") 
        {
            background.color = Color.green;
        } else if (cardGod == "Etse")
        {
            background.color = Color.black;
            textCardName.color = Color.white;
        } else if (cardGod == "Miknit")
        {
            background.color = Color.blue;
        } else if (cardGod == "Chronos")
        {
            background.color = Color.yellow;
        } else if (cardGod == "Murgu")
        {
            background.color = Color.red;
        } else if (cardGod == "Yrys")
        {
            background.color = Color.magenta;
        }
        else
        {
            background.color = Color.white;
        }
        
    }

    public void removeCard()
    {
        deckCreator.RemoveCardFromDeck(localCardName);
        Destroy(gameObject, 0.2f);
    }
   
}
