using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> graveyard = new List<Card>();
    public List<Card> banished = new List<Card>();
    public List<Card> hand = new List<Card>();
    public List<Card> field = new List<Card>();
    public List<Card> returnCards = new List<Card>();

    int randomCard = 0;
    [SerializeField] int deckSize;
    private int cardsOnDeck;


    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;  
    public GameObject cardInDeck4;
    public GameObject cardInDeck5;
    public GameObject cardInDeck6;

    [SerializeField] GameObject Hand;
    [SerializeField] GameObject Field;
    [SerializeField] GameObject Card;

    [SerializeField] TurnManager turnManager;

    private bool canDestroy = false;

    void Start()
    {
        for (int i = 0; i <= deck.Count-1;  i++)
        {
            randomCard = Random.Range(1, 120);
            
            deck[i] = CardDatabase.cardList[randomCard];
        }

        DeckChanges();

      
        
       
    }

    public void CallDraw(int numberOfDrawCards)
    {
        for (int i = 1; i < (numberOfDrawCards+1); i++)
        {
            DrawCard(i);
            DeckChanges();
        }
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
        if (deck.Count < 51)
        {
            cardInDeck1.SetActive(false);
        } else if (deckSize > 51)
        {
            cardInDeck1.SetActive(true);
            return;
        }
        
        if (deck.Count < 41)
        {
            cardInDeck2.SetActive(false);
        }else if (deckSize > 41)
        {
            cardInDeck2.SetActive(true) ;
            return;
        }
        if (deck.Count < 31)
        {
            cardInDeck3.SetActive(false);
        } else if (deckSize > 31)
        {
            cardInDeck3.SetActive(true) ;
            return;
        }

        if (deck.Count < 21)
        {
            cardInDeck4.SetActive(false);
        } else if (deckSize > 21)
        {
            cardInDeck4.SetActive(true) ;
            return;
        }
        if (deck.Count < 11)
        {
            cardInDeck5.SetActive(false);
        } else if (deckSize > 11)
        {
            cardInDeck5.SetActive(true) ;
            return;
        }
        if (deck.Count < 1)
        {
            cardInDeck6.SetActive(false);
        }else if (deck.Count > 1)
        {
            cardInDeck6.SetActive(true) ;
            return;
        }
        
    }

    private void DrawCard(int cardId)
    {
       GameObject CardInHand = Instantiate(Card,new Vector3(0,0,0), Quaternion.identity);
        CardInHand.transform.SetParent(Hand.transform);
        DisplayCard displayCard;
        displayCard = CardInHand.GetComponent<DisplayCard>();


        int lastCard = deck.Count;
        displayCard.updateDisplay(deck[cardId].cardId);
        displayCard.WhereIAm(1);
        hand.Add(deck[cardId]);
        deck.RemoveAt(cardId);
        
        
    }

    public void ReturnCard(Card card)
    {
        deck.Add(card);
        
    }

    //! where
    //? 0 None
    //? 1 Deck
    //? 2 Cementerio
    //? 3 Destierros
    //? 4 Campo

   
    public List<Card> SearchCards(string what = "", int cost = 0, string who = "", int where = 0, string from = "")
    {
       
        
        if (where == 1) // ? Deck
        {

            if (who != "")
            {
                for (int i = 0; i < deck.Count; i++)
                {
                    if (deck[i].cardName == who)
                    {
                        returnCards.Add(deck[i]);
                    }
                    
                }
                return returnCards;
            }

            if (from != "")
            {
                for (int i = 0; i < deck.Count; i++)
                {
                    if (deck[i].cardType == from)
                    {
                        returnCards.Add(deck[i]);
                    }
                }
                return returnCards;
            }

            if (cost != 0)
            {

                for (int i = 0; i < deck.Count; i++)
                {
                    if (deck[i].cardCost == cost)
                    {
                        returnCards.Add(deck[i]);
                    }
                }
                return returnCards;
            }

            if (what != "")
            {

                for (int i = 0; i < deck.Count; i++)
                {
                    if (what == "chosen" || what == "Chosen")
                    {
                        if (deck[i].cardHealth != 0)
                        {
                            returnCards.Add(deck[i]);
                        }
                    } 
                    else if (deck[i].cardClass == what)
                    {
                        returnCards.Add(deck[i]);
                    }
                }
                return returnCards;
            }


        } else if (where == 2) //? Cementerio
        {

            if (who != "")
            {
                for (int i = 0; i < graveyard.Count; i++)
                {
                    if (graveyard[i].cardName == who)
                    {
                        returnCards.Add(graveyard[i]);
                    }

                }
                return returnCards;
            }

            if (from != "")
            {
                for (int i = 0; i < graveyard.Count; i++)
                {
                    if (graveyard[i].cardType == from)
                    {
                        returnCards.Add(graveyard[i]);
                    }
                }
                return returnCards;
            }

            if (cost != 0)
            {

                for (int i = 0; i < graveyard.Count; i++)
                {
                    if (graveyard[i].cardCost == cost)
                    {
                        returnCards.Add(graveyard[i]);
                    }
                }
                return returnCards;
            }

            if (what != "")
            {

                for (int i = 0; i < graveyard.Count; i++)
                {
                    if (what == "chosen" || what == "Chosen")
                    {
                        if (graveyard[i].cardHealth != 0)
                        {
                            returnCards.Add(graveyard[i]);
                        }
                    }
                    else if (graveyard[i].cardClass == what)
                    {
                        returnCards.Add(graveyard[i]);
                    }
                }
                return returnCards;
            }


        }
        else if (where == 3) //? Destierros
        {
            if (who != "")
            {
                for (int i = 0; i < banished.Count; i++)
                {
                    if (banished[i].cardName == who)
                    {
                        returnCards.Add(banished[i]);
                    }

                }
                return returnCards;
            }

            if (from != "")
            {
                for (int i = 0; i < banished.Count; i++)
                {
                    if (banished[i].cardType == from)
                    {
                        returnCards.Add(banished[i]);
                    }
                }
                return returnCards;
            }

            if (cost != 0)
            {

                for (int i = 0; i < banished.Count; i++)
                {
                    if (banished[i].cardCost == cost)
                    {
                        returnCards.Add(banished[i]);
                    }
                }
                return returnCards;
            }

            if (what != "")
            {

                for (int i = 0; i < banished.Count; i++)
                {
                    if (what == "chosen" || what == "Chosen")
                    {
                        if (banished[i].cardHealth != 0)
                        {
                            returnCards.Add(banished[i]);
                        }
                    }
                    else if (banished[i].cardClass == what)
                    {
                        returnCards.Add(banished[i]);
                    }
                }
                return returnCards;
            }


        }
        else if (where == 4) //? Campo
        {
            if (who != "")
            {
                for (int i = 0; i < field.Count; i++)
                {
                    if (field[i].cardName == who)
                    {
                        returnCards.Add(field[i]);
                    }

                }
                return returnCards;
            }

            if (from != "")
            {
                for (int i = 0; i < field.Count; i++)
                {
                    if (field[i].cardType == from)
                    {
                        returnCards.Add(field[i]);
                    }
                }
                return returnCards;
            }

            if (cost != 0)
            {

                for (int i = 0; i < field.Count; i++)
                {
                    if (field[i].cardCost == cost)
                    {
                        returnCards.Add(field[i]);
                    }
                }
                return returnCards;
            }

            if (what != "")
            {

                for (int i = 0; i < field.Count; i++)
                {
                    if (what == "chosen" || what == "Chosen")
                    {
                        if (field[i].cardHealth != 0)
                        {
                            returnCards.Add(field[i]);
                        }
                    }
                    else if (field[i].cardClass == what)
                    {
                        returnCards.Add(field[i]);
                    }
                }
                return returnCards;
            }

        }






        foreach (Card card in deck)
        {
            returnCards.Add(card);
        }


        return returnCards;
    }

    public void canPlayCard(Card card)
    {
        if (field.Count >= 6)
        {
            return;
        }

        
        if (!turnManager.checkMana(card.cardType, card.cardCost))
        {
            return;
            
        }

       
        for (int i = 0; i < hand.Count; i++)
        {
            if (hand[i] == card)
            {
                canDestroy = true;
                PlayCard(card);


            }
        }

       
        return;
    }

    public void PlayCard(Card card)
    {


            GameObject CardInHand = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            CardInHand.transform.SetParent(Field.transform);
            DisplayCard displayCard;
            displayCard = CardInHand.GetComponent<DisplayCard>();


            
            displayCard.updateDisplay(card.cardId);
            displayCard.WhereIAm(2);
            field.Add(card);
            hand.Remove(card);
          
        
    }

    public bool ConfirmDestruction()
    {

        if (canDestroy)
        {
            canDestroy = false;
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
