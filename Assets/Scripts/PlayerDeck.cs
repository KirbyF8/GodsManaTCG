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

    public Card zonaDeDominio = null; 

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

    //! Sustituirlo más adelante
    [SerializeField] bool rivalHand;
    [SerializeField] GameObject domainCard;


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
        if (rivalHand)
        {
            displayCard.WhereIAm(5);
            displayCard.faceDown();
        }
        hand.Add(deck[cardId]);
        deck.RemoveAt(cardId);
        
        
    }

    public void DrawSelectedCards(List<Card> selectedCards)
    {
        foreach (Card card in selectedCards)
        {
            GameObject CardInHand = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            CardInHand.transform.SetParent(Hand.transform);
            DisplayCard displayCard;
            displayCard = CardInHand.GetComponent<DisplayCard>();

            displayCard.updateDisplay(card.cardId);
            displayCard.WhereIAm(1);

            hand.Add(deck[card.cardId]);
            deck.RemoveAt(card.cardId);

        }
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
    //? 5 ReturnCards 
    //? 6 Mano y Deck
    //? 7 Fichas
   
    public List<Card> SearchCards(string what = "", int cost = 0, string who = "", int where = 0, string from = "")
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
               SearchFrom(deck, from, false);
            where = 5;
            }

            if (cost != 0)
            {
              SearchCost(deck, cost);
            where = 5;

        }

            if (what != "")
            {

                SearchWhat(deck, what);
            where = 5;

        }

        return returnCards;
       
    }

    public List<Card> SearchFrom(List<Card> whereList, string from, bool reEnter)
    {
        if (!reEnter)
        {
            for (int i = 0; i < whereList.Count; i++)
            {
                if (whereList[i].cardType == from)
                {
                    returnCards.Add(whereList[i]);
                }
            }
            return returnCards;
        } 
        
        /*
        else
        {
            for (int i = 0; i < returnCards.Count; i++)
            {
                if (returnCards[i].cardType == from)
                {
                    returnCards.Remove(returnCards[i]);
                }
            }
            return returnCards;
        }
        */
        return returnCards;


    }
    public List<Card> SearchCost(List<Card> whereList, int cost)
    {
       
            for (int i = 0; i < whereList.Count; i++)
            {
                if (whereList[i].cardCost == cost)
                {
                    returnCards.Add(whereList[i]);
                }
            }
            return returnCards;
        
        
           
        
    
        
    }

    public List<Card> SearchWhat(List<Card> whereList, string what)
    {

        
            for (int i = 0; i < whereList.Count; i++)
            {
                if (what == "elegido" || what == "Elegido")
                {
                    if (whereList[i].cardHealth != 0)
                    {
                        returnCards.Add(whereList[i]);
                    }
                }
                else if (whereList[i].cardClass == what)
                {
                    returnCards.Add(whereList[i]);
                }
            }
            return returnCards;
        
           
        
        
    }



    public void CleanSearch()
    {
        returnCards.Clear();
    }

    public void DestroyCard(Card card)
    {
        field.Remove(card);
        graveyard.Add(card);

    }

    public void canPlayCard(Card card)
    {
        if (!turnManager.isYourTurn)
        {
            return;
        }
        
        if (field.Count >= 6 && card.cardClass != "Mágica" && card.cardClass != "Trampa")
        {
            // !No hay hueco en el campo
           
            return;
           
        }

        // TODO Equipo
        //? Comprobar si hay Elegidos, Comprobar que almenos 1 no tenga cartas de equipo, Dejar al jugador a quien ponesela,, Jugar carta


       
        
        if (!turnManager.checkMana(card.cardType, card.cardCost))
        {
           
            //! No tienes Mana suficiente
            return;
            
        }

        if (!turnManager.CanSummonFase())
        {

            //! No puedes usar cartas en esta fase
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

        if (card.cardClass == "Dominio")
        {
            domainCard.SetActive(true);
            if (zonaDeDominio == null)
            {
                
                zonaDeDominio = card;
                DisplayCard displayCardD = domainCard.GetComponent<DisplayCard>();
                displayCardD.updateDisplay(zonaDeDominio.cardId);
                displayCardD.WhereIAm(9);
                hand.Remove(card);
                return;
            }
            else
            {
                //TODO Destroy Domain
                graveyard.Add(zonaDeDominio);
                zonaDeDominio = card;
                DisplayCard displayCardD = domainCard.GetComponent<DisplayCard>();
                displayCardD.updateDisplay(zonaDeDominio.cardId);
                displayCardD.WhereIAm(9);
                hand.Remove(card);
                return;

            }
        }

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
