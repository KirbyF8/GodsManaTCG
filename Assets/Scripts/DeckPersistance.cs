using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPersistance : MonoBehaviour
{

    private string path = Application.dataPath + "/../saves/" + "save.json";
    private string statsPath = Application.dataPath + "/../deck saves/";

    private static List<int> cardOnDeckList = new List<int>();

    private int cardOnDeckId;
 

   public void AddToDeck(int cardSelectedId)
    {
        cardOnDeckList.Add(cardSelectedId);
    }
    public void RemoveFromDeck(int cardSelectedId)
    {
        cardOnDeckList.Remove(cardSelectedId);
    }

    public void SaveDeck()
    {

    }

    public void DeleteDeck()
    {
        cardOnDeckList.Clear();
    }
}
