using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> holder = new List<Card>();
    int randomCard = 0;
    [SerializeField] int deckSize;
    private int cardsOnDeck;

    void Start()
    {
        for (int i = 0; i <= deckSize;  i++)
        {
            randomCard = Random.Range(1, 100);
            deck[i] = CardDatabase.cardList[randomCard];
        }
       
    }

    private void ShuffleDeck()
    {
        
    }
}
