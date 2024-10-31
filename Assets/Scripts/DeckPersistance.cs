using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPersistance : MonoBehaviour
{

    private string path = Application.dataPath + "/../saves/" + "save.json";
    private string statsPath = Application.dataPath + "/../deck saves/";

    

    public void SaveDeck(List<Card> cards)
    {

    }

    public void DeleteDeck()
    {
       
    }
}
