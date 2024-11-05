using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting;

[System.Serializable]
public class CardSaveListWrapper
{
    public List<Card> cards;
}

public class DeckPersistance : MonoBehaviour
{

    private string path = Application.dataPath + "/../saves/" + "save.json";
    private string statsPath = Application.dataPath + "/../deck saves/";

    public List<Card> cardSaveList = new List<Card>();

    //! Comprobar Mas tarde
    private List<Card> DeckSave = new List<Card>();

  
    

    public void SaveDeck()
    {

    }

    public void DeleteDeck()
    {
       
    }


    public void SaveCards()
    {
        CardSaveListWrapper wrapper = new CardSaveListWrapper { cards = cardSaveList };
        string json = JsonUtility.ToJson(wrapper, true);
       
        File.WriteAllText(path, json);
    }
    public void LoadSavedCards()
    {

    }

    public void AddSaveCard(Card card)
    {
        cardSaveList.Add(card);
    }

    public void RemoveSaveCard(Card card)
    {
        cardSaveList.Remove(card);
    }

    private int returnNumberOfCards;
    public int NumberOfCards(Card card)
    {
        foreach (Card card2 in cardSaveList)
        {
            if (card.cardName == card2.cardName)
            {
                returnNumberOfCards++;
            }
        }

        return returnNumberOfCards;
    }
}
