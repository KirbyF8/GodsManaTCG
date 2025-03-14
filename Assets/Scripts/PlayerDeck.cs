using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using Random = UnityEngine.Random;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> graveyard = new List<Card>();
    public List<Card> banished = new List<Card>();
    public List<GameObject> hand = new List<GameObject>();

    public List<GameObject> field = new List<GameObject>();
   

    public List<Card> returnCards = new List<Card>();

    public Card zonaDeDominio = null; 

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
    [SerializeField] EfectosDiccionario effectDictionary;
    [SerializeField] CardEffects effects;

    //! Sustituirlo m�s adelante
    [SerializeField] bool rivalHand;
    [SerializeField] PlayerDeck rivalDeck;
    [SerializeField] GameObject domainCard;

    [SerializeField] AI aI;

    [SerializeField] DeckPersistance deckPersistance;
    private List<int> cardsID;



    private bool canDestroy = false;

    void Start()
    {
        
        //? --- Preparar Decks ---
       
       if (rivalHand)
            {
            /*
               cardsID = deckPersistance.ReturnAIDeck(PlayerPrefs.GetString("lvl"));
                LoadDeck();*/
            LoadRandomDeck();
            }
       else
        {
            LoadRandomDeck();
        }
            
           
            

          
        

        DeckChanges();

      
        
       
    }

    private int cardCounter;

    private void LoadRandomDeck()
    {
        for (int i = 0; i < 30; i++)
        {
            int r = Random.Range(0, 158);
            deck[i] = CardDatabase.cardList[r];
        }
    }
   private void LoadDeck()
    {
        cardCounter = 0;
        foreach (int id in cardsID)
        {
            deck[cardCounter] = CardDatabase.cardList[id];
            cardCounter++;
        }
        
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
        } else
        {
            cardInDeck1.SetActive(true);
            return;
        }
        
        if (deck.Count < 41)
        {
            cardInDeck2.SetActive(false);
        }else 
        {
            cardInDeck2.SetActive(true) ;
            return;
        }
        if (deck.Count < 31)
        {
            cardInDeck3.SetActive(false);
        } else 
        {
            cardInDeck3.SetActive(true) ;
            return;
        }

        if (deck.Count < 21)
        {
            cardInDeck4.SetActive(false);
        } else 
        {
            cardInDeck4.SetActive(true) ;
            return;
        }
        if (deck.Count < 11)
        {
            cardInDeck5.SetActive(false);
        } else 
        {
            cardInDeck5.SetActive(true) ;
            return;
        }
        if (deck.Count < 1)
        {
            cardInDeck6.SetActive(false);
        }else 
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
        displayCard.UpdateDisplay(deck[cardId].cardId);
        displayCard.WhereIAm(1);
        if (rivalHand)
        {
            displayCard.WhereIAm(5);
            displayCard.FaceDown();
        }
        hand.Add(CardInHand);
        deck.RemoveAt(cardId);
        
        
    }


    //? IA Necesita Cambios
    public void DrawSelectedCards(List<Card> selectedCards)
    {
        foreach (Card card in selectedCards)
        {
            GameObject CardInHand = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            CardInHand.transform.SetParent(Hand.transform);
            DisplayCard displayCard;
            displayCard = CardInHand.GetComponent<DisplayCard>();

            displayCard.UpdateDisplay(card.cardId);
            displayCard.WhereIAm(1);

            hand.Add(CardInHand);
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
        //! COMPROBAR Q FUNCIONE
        
        rivalDeck.graveyard.Add(card);

        foreach (GameObject go in field)
        {
            DisplayCard displayCardD = go.GetComponent<DisplayCard>();
            if (displayCardD.GetThisCard() == card)
            {
                field.Remove(go);
                
                Destroy(go, 0.1f);
                return;
            }
        }

    }

    public void canPlayCard(Card card)
    {
        if (!turnManager.isYourTurn)
        {
            return;
        }
        
        if (field.Count >= 6 && card.cardClass != "M�gica" && card.cardClass != "Trampa")
        {
            // !No hay hueco en el campo
           
            return;
           
        }

        // TODO Equipo
        //! Comprobar si hay Elegidos, Comprobar que almenos 1 no tenga cartas de equipo, Dejar al jugador a quien ponesela,, Jugar carta


       
        
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

      

      
         
                
                canDestroy = true;
                PlayCard(card);


            
        

       
        return;
    }

    public bool CanPlayCardAI(Card card)
    {

        if (field.Count >= 6 && card.cardClass != "M�gica" && card.cardClass != "Trampa")
        {

            return false;

        }

        // TODO Equipo
        //! Comprobar si hay Elegidos, Comprobar que almenos 1 no tenga cartas de equipo, Dejar al jugador a quien ponesela,, Jugar carta

        if (!turnManager.checkMana(card.cardType, card.cardCost))
        {

            //! No tienes Mana suficiente
            return false;

        }


        return true;
    }
    GameObject CardToRemove;
    public void PlayCard(Card card)
    {

        
        if (card.cardClass == "Dominio")
        {
            domainCard.SetActive(true);
            if (zonaDeDominio == null)
            {
                turnManager.ManaChanges(card.cardType, 2, card.cardCost);
                zonaDeDominio = card;
                DisplayCard displayCardD = domainCard.GetComponent<DisplayCard>();
                displayCardD.UpdateDisplay(zonaDeDominio.cardId);
                displayCardD.WhereIAm(9);

                foreach (var item in hand)
                {
                    DisplayCard aux = item.GetComponent<DisplayCard>();
                    if (card == aux.GetThisCard())
                    {
                        CardToRemove = item;
                    }
                    
                }
                DisplayCard cardToDestroy3 = CardToRemove.GetComponent<DisplayCard>();
                cardToDestroy3.Destruction();
                hand.Remove(CardToRemove);
                CardToRemove = null;
                return;
            }
            else
            {
                turnManager.ManaChanges(card.cardType, 2, card.cardCost);
                graveyard.Add(zonaDeDominio);
                zonaDeDominio = card;
                DisplayCard displayCardD = domainCard.GetComponent<DisplayCard>();
                displayCardD.UpdateDisplay(zonaDeDominio.cardId);
                displayCardD.WhereIAm(9);
                foreach (var item in hand)
                {
                    DisplayCard aux = item.GetComponent<DisplayCard>();
                    if (card == aux.GetThisCard())
                    {
                        CardToRemove = item;
                    }

                }
                DisplayCard cardToDestroy2 = CardToRemove.GetComponent<DisplayCard>();
                cardToDestroy2.Destruction();
                hand.Remove(CardToRemove);
                CardToRemove=null;
                return;

            }
        }

        GameObject CardInHand = Instantiate(Card, new Vector3(0, 0, 0), Quaternion.identity);
            CardInHand.transform.SetParent(Field.transform);
            DisplayCard displayCard;
          
            displayCard = CardInHand.GetComponent<DisplayCard>();
        displayCard.UpdateDisplay(card.cardId);
        displayCard.WhereIAm(2);
        
        Card actualCard = displayCard.GetThisCard();
        /* 
         * if (turnManager.isYourTurn)
        {

      
        if (actualCard.activationTypes != null && actualCard.activationTypes.Count >= 1)
        {

            if (actualCard.activationTypes.Contains(EfectosDiccionario.ActivationType.OnEnterField))
            {


                if (actualCard.activationTypes[0] == EfectosDiccionario.ActivationType.OnEnterField)
                {
                    effects.effectActions[actualCard.cardEffect[0]](new EffectParam
                    {
                        howMany = actualCard.effectHowMany[0],
                        who = actualCard.effectTargetName[0],
                        what = actualCard.effectCardClass[0],
                        HP = actualCard.effectHP[0],
                        ATK = actualCard.effectATK[0],
                        cost = actualCard.effectCost[0],
                        DEF = actualCard.effectDEF[0],
                        where = actualCard.effectWhere[0],
                        from = actualCard.effectCardDeity[0]
                    });
                }
                else
                {
                    effects.effectActions[actualCard.cardEffect[1]](new EffectParam
                    {
                        howMany = actualCard.effectHowMany[1],
                        who = actualCard.effectTargetName[1],
                        what = actualCard.effectCardClass[1],
                        HP = actualCard.effectHP[1],
                        ATK = actualCard.effectATK[1],
                        cost = actualCard.effectCost[1],
                        DEF = actualCard.effectDEF[1],
                        where = actualCard.effectWhere[1],
                        from = actualCard.effectCardDeity[1]
                    });
                }

            }
        }
        
        }*/
        turnManager.ManaChanges(card.cardType, 2, card.cardCost);
        displayCard.UpdateDisplay(card.cardId);
        if (turnManager.isYourTurn)
        {
            displayCard.WhereIAm(2);
        }
        else
        {
            displayCard.WhereIAm(8);
        }
        
            field.Add(CardInHand);
        

        CardToRemove = null;
        foreach (GameObject item in hand)
        {
            DisplayCard aux = item.GetComponent<DisplayCard>();
  

            if (card == aux.GetThisCard())
            {
                
                CardToRemove = item;
                DisplayCard cardToDestroy = CardToRemove.GetComponent<DisplayCard>();
                cardToDestroy.DestructionAI();
                cardToDestroy.Destruction();
                break;
            }

        }
        
     
        hand.Remove(CardToRemove);
          
        
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

    public void AddToGraveYard(Card card)
    {
        graveyard.Add(card);
    }
    public void AiTurn()
    {
        aI.SummonFase(hand);
    }

    public void AiBattle()
    {
        aI.BattleFase(field);
    }
}
