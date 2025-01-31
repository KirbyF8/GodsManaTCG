using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;


public class CardEffects : MonoBehaviour
{
    [SerializeField] PlayerDeck playerDeck;

    public List<Card> returnedCards = new List<Card>();
    public List<Card> selectedCards = new List<Card>();

    [SerializeField] GameObject confirmCardPanel;

    private int howMany;

    [SerializeField] private GameObject GOcard;

    [SerializeField] private GameObject searchedCardsPlace;

    [SerializeField] private GameObject nothing;

    [SerializeField] private TMP_Text howManyText;

    private int howManyI;

    private void Start()
    {
        effectActions.Add(1, CardEffect_DrawCards);
        effectActions.Add (2, CardEffect_DestroyCards);
        effectActions.Add(3, CardEffect_BanishCards);
        effectActions.Add(4, CardEffect_LookCards);
        //effectActions.Add(5, CardEffect_Buff);
    }
    public Dictionary<int, Action<EffectParam>> effectActions = new Dictionary<int, Action<EffectParam>>

    {
        
            //{ 1, CardEffect_DrawCards}
            //{ 2, CardEffect_DestroyCards},
            //{ 3, CardEffect_BanishCards },
            //{ 4, CardEffect_LookCards },
            //{ 5, CardEffect_Buff },
            //{ 6, CardEffect_Damage_Heal },
            //{ 7, CardEffect_Taunt },
            //{ 8, CardEffect_ManaChanges },
            //{ 9, CardEffect_LimitCards },
            //{ 10, CardEffect_Constants }, 
            //{ 11, CardEffect_Summon },
            //{ 12, CardEffect_RetreatChosenDeck },
            //{ 13, CardEffect_RetreatChosenHand},
            //{ 14, CardEffect_Constants}
        



        };


    // Inicializa el diccionario con las funciones que encapsulan los efectos


    public void CardEffect_DrawCards(EffectParam ep)
    {
        howManyI = howMany;
        returnedCards = playerDeck.SearchCards(ep.what, ep.cost, ep.who, ep.where, ep.from);
        confirmCardPanel.SetActive(true);
        howManyText.color = Color.black;
        howManyText.text = "Selecciona " + howMany + " Cartas";

        GenerateSelectableCards();
        playerDeck.CleanSearch();
    }

 
   
    public void SelectCards(Card card)
    {
     
            selectedCards.Add(card);
           
        
    }

    public void DeSelectCards(Card card)
    {
        
            selectedCards.Remove(card);

        
    }
    public void ConfirmCardsDrawed()
    {
       
        if (selectedCards.Count == howManyI)
        {
            
            playerDeck.DrawSelectedCards(selectedCards);

            selectedCards.Clear();
            nothing.SetActive(false);
            confirmCardPanel.SetActive(false);
        }
        else
        {
            //TODO Sonido de fallo
            howManyText.color = Color.red;
        }
       
    }

    public void CardEffect_DestroyCards(EffectParam ep)
    {
        howManyI = howMany;
        returnedCards = playerDeck.SearchCards(ep.what, ep.cost, ep.who, 4, ep.from);
        confirmCardPanel.SetActive(true);
        howManyText.color = Color.black;
        howManyText.text = "Selecciona " + howMany + " Cartas para destrur";

        GenerateSelectableCards();

    }

    public void ConfirmCardsDestroyed()
    {

        if (selectedCards.Count == howManyI)
        {

            foreach(Card card in selectedCards)
            {
                playerDeck.DestroyCard(card);
             
            }

            selectedCards.Clear();
            nothing.SetActive(false);
            confirmCardPanel.SetActive(false);

            //TODO Eliminar cartas
        }
        else
        {
            //TODO Sonido de fallo
            howManyText.color = Color.red;
        }

    }

    private void GenerateSelectableCards()
    {
        if (returnedCards == null || returnedCards.Count <= 0)
        {
            howManyText.text = "Pulse Confirmar";
            howManyText.color = Color.red;
            nothing.SetActive(true);

        }

        foreach (Card card in returnedCards)
        {
            GameObject CardInSeach = Instantiate(GOcard, new Vector3(0, 0, 0), Quaternion.identity);
            CardInSeach.transform.SetParent(searchedCardsPlace.transform);
            DisplayCard displayCard;
            displayCard = CardInSeach.GetComponent<DisplayCard>();



            displayCard.UpdateDisplay(card.cardId);
            displayCard.WhereIAm(4);

        }

        returnedCards.Clear();
    }


    public void CardEffect_Summon(EffectParam ep)
    {
        howManyI = howMany;
        returnedCards = playerDeck.SearchCards(ep.what, ep.cost, ep.who, ep.where, ep.from);
        confirmCardPanel.SetActive(true);
        howManyText.color = Color.black;
        howManyText.text = "Selecciona " + howMany + " elegidos para invocarlos";

        GenerateSelectableCards();

    }

    public void CardEffect_Damage_Heal()
    {

    }

    public void CardEffect_Buff()
    {

    }

    public void CardEffect_BanishCards(EffectParam ep)
    {
        howManyI = howMany;
        returnedCards = playerDeck.SearchCards(ep.what, ep.cost, ep.who, ep.where, ep.from);
        confirmCardPanel.SetActive(true);
        howManyText.color = Color.black;
        howManyText.text = "Selecciona " + howMany + " elegidos para desterrarlos";

        GenerateSelectableCards();
    }

    public void CardEffect_LookCards(EffectParam ep)
    {
        howManyI = howMany;
        returnedCards = playerDeck.SearchCards(ep.what, ep.cost, ep.who, ep.where, ep.from);
        confirmCardPanel.SetActive(true);
        howManyText.color = Color.black;
        howManyText.text = "0-0";
    }

    public void CardEffect_LimitCards()
    {

    }

    public void CardEffect_Taunt()
    {

    }

    public void CardEffect_ManaChanges()
    {

    }

    public void CardEffect_Constants()
    {

    }
}
