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
    public List<int> cardsID;
    public List<Card> deckCards;
}

public class DeckPersistance : MonoBehaviour
{

    private string path = Application.dataPath + "/../saves/" + "save.json";
    private string deckPath = Application.dataPath + "/../saves/" + "DeckSave";
    private string nameOfDeckPath;

    public List<Card> cardSaveList = new List<Card>();
    public List<int> cardIDs = new List<int>();

    //! Hacer Mas tarde
    private List<Card> DeckSave = new List<Card>();


    private void Start()
    {
        LoadSavedCards();
    }

    public void SaveDeck(List<Card> deck, string filename)
    {
        DeckSave = deck;
        nameOfDeckPath = deckPath + filename;

        if (File.Exists(nameOfDeckPath)) 
        {
            Debug.LogError("Ya hay un deck con ese nombre");
            return;
        }
        else
        {
            CardSaveListWrapper wrapper = new CardSaveListWrapper { deckCards = DeckSave };
            string json = JsonUtility.ToJson(wrapper, true);
            File.WriteAllText(nameOfDeckPath+".json", json);
        }
    }

    public void DeleteDeck(string filename)
    {
        nameOfDeckPath = deckPath + filename;
        File.Delete(nameOfDeckPath + ".json");
    }

   
    public void SaveCards()
    {


        // Cargar IDs existentes desde el archivo (si existe)
        List<int> existingCardIDs = new List<int>();

        if (File.Exists(path))
        {
            string existingJson = File.ReadAllText(path);
            CardSaveListWrapper existingWrapper = JsonUtility.FromJson<CardSaveListWrapper>(existingJson);
            existingCardIDs = existingWrapper.cardsID;
        }

        // Agregar los nuevos card IDs al listado existente
        for (int i = 0; i < cardSaveList.Count; i++)
        {
            
                existingCardIDs.Add(cardSaveList[i].cardId);
            
        }

        // Crear un nuevo wrapper con todos los IDs y guardarlo
        CardSaveListWrapper wrapper = new CardSaveListWrapper { cardsID = existingCardIDs };
        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, json);
        cardIDs.Clear();
    }

    

    public void LoadSavedCards()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            CardSaveListWrapper wrapper = JsonUtility.FromJson<CardSaveListWrapper>(json);
            cardIDs = wrapper.cardsID;
        }
        else
        {
            Debug.Log("Donde esta mi archivo??");
        }
    }

    public void AddSaveCard(Card card)
    {
        cardSaveList.Clear();
        cardSaveList.Add(card);
    }

    public void RemoveSaveCard(Card card)
    {
        cardSaveList.Add(card);
    }

    private int returnNumberOfCards;
    public int NumberOfCards(Card card)
    {
        returnNumberOfCards = 0;  
        for (int i=0; i < cardIDs.Count; i++)
        {
       
            if (cardIDs[i] == card.cardId)
            {
                returnNumberOfCards++;
            }
        }

        return returnNumberOfCards;
    }

    public void RemoveCards(Card card)
    {
        LoadSavedCards();
        for (int i = 0; i < cardIDs.Count; i++)
        {
            if (card.cardId == cardIDs[i])
            {
                cardIDs.RemoveAt(i);
                return;
                
            }
        }
    }
}
