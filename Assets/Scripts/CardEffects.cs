using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

  
    public void CardEffect_DrawCards(string what = "", int cost = 0, string who = "", int where = 0, string from = "", int howMany = 1)
    {
        howManyI = howMany;
        returnedCards = playerDeck.SearchCards(what ,cost ,who ,where, from);
        confirmCardPanel.SetActive(true);
        howManyText.color = Color.black;
        howManyText.text = "Selecciona " + howMany + " Cartas";

        GenerateSelectableCards();
        // playerDeck.CleanSearch();
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

    public void CardEffect_DestroyCards(string what = "", int cost = 0,int where = 4, string who = "", string from = "", int howMany = 1)
    {
        howManyI = howMany;
        returnedCards = playerDeck.SearchCards(what, cost, who, where, from);
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
                playerDeck.field.Remove(card);
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



            displayCard.updateDisplay(card.cardId);
            displayCard.WhereIAm(4);

        }

        returnedCards.Clear();
    }

    public void CardEffect_Summon(string what = "", int cost = 0, int where = 1, string who = "", string from = "", int howMany = 1)
    {
        howManyI = howMany;
        returnedCards = playerDeck.SearchCards(what, cost, who, where, from);
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

    public void CardEffect_BanishCards(string what = "", int cost = 0, int where = 1, string who = "", string from = "", int howMany = 1)
    {
        howManyI = howMany;
        returnedCards = playerDeck.SearchCards(what, cost, who, where, from);
        confirmCardPanel.SetActive(true);
        howManyText.color = Color.black;
        howManyText.text = "Selecciona " + howMany + " elegidos para desterrarlos";

        GenerateSelectableCards();
    }

    public void CardEffect_LookCards()
    {

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
