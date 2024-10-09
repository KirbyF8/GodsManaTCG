using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    
    int randomCard = 0;
    [SerializeField] int deckSize;
    private int cardsOnDeck;


    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;  
    public GameObject cardInDeck4;
    public GameObject cardInDeck5;
    public GameObject cardInDeck6;

    void Start()
    {
        for (int i = 0; i <= deckSize-1;  i++)
        {
            randomCard = Random.Range(1, 100);
            deck[i] = CardDatabase.cardList[randomCard];
        }

        DeckChanges();
       
    }

    public void ShuffleDeck()
    {
        Card auxCard = null;
        for (int i = 0; i < deckSize; i++)
        {
            int randomIdx = Random.Range(i, deckSize);
            auxCard = deck[i];
            deck[i] = deck[randomIdx];
            deck[randomIdx] = auxCard;

            
        }
    }

    private void DeckChanges()
    {
        if (deckSize < 51)
        {
            cardInDeck1.SetActive(false);
        } else if (deckSize > 51)
        {
            cardInDeck1.SetActive(true);
            return;
        }
        
        if (deckSize < 41)
        {
            cardInDeck2.SetActive(false);
        }else if (deckSize > 41)
        {
            cardInDeck2.SetActive(true) ;
            return;
        }
        if (deckSize < 31)
        {
            cardInDeck3.SetActive(false);
        } else if (deckSize > 31)
        {
            cardInDeck3.SetActive(true) ;
            return;
        }

        if (deckSize < 21)
        {
            cardInDeck4.SetActive(false);
        } else if (deckSize > 21)
        {
            cardInDeck4.SetActive(true) ;
            return;
        }
        if (deckSize < 11)
        {
            cardInDeck5.SetActive(false);
        } else if (deckSize > 11)
        {
            cardInDeck5.SetActive(true) ;
            return;
        }
        if (deckSize < 1)
        {
            cardInDeck6.SetActive(false);
        }else if (deckSize > 1)
        {
            cardInDeck6.SetActive(true) ;
            return;
        }
        
    }
}
