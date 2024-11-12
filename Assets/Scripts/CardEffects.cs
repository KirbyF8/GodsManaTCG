using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class CardEffects : MonoBehaviour
{
    [SerializeField] PlayerDeck playerDeck;

    public List<Card> returnedCards = new List<Card>();
    private List<Card> selectedCards = new List<Card>();

    [SerializeField] GameObject confirmCardPanel;

    private int howMany;

    [SerializeField] private GameObject GOcard;

    [SerializeField] private GameObject searchedCardsPlace;

  
    public void CardEffect_DrawCards(string what = "", int cost = 0, string who = "", int where = 0, string from = "", int howMany = 1)
    {
        returnedCards = playerDeck.SearchCards(what ,cost ,who ,where, from);
        confirmCardPanel.SetActive(true);
        
        if (returnedCards == null || returnedCards.Count <= 0)
        {
            Debug.Log("A");
        }
       
        foreach (Card card in returnedCards )
        {
            GameObject CardInSeach = Instantiate(GOcard, new Vector3(0, 0, 0), Quaternion.identity);
            CardInSeach.transform.SetParent(searchedCardsPlace.transform);
            DisplayCard displayCard;
            displayCard = CardInSeach.GetComponent<DisplayCard>();


            
            displayCard.updateDisplay(card.cardId);
            displayCard.WhereIAm(4);
          
        }
        // playerDeck.CleanSearch();
    }
    public void SelectCards(Card card)
    {
     if (selectedCards.Count >= howMany) 
        { 
        selectedCards.Clear();
        }
     else
        {
            selectedCards.Add(card);

        }
    }
    public void ConfirmCardsDrawed()
    {


        selectedCards.Clear();
        confirmCardPanel.SetActive(false);
    }

    public void CardEffect_DestroyCards()
    {

    }

    public void CardEffect_Summon()
    {

    }

    public void CardEffect_Damage_Heal()
    {

    }

    public void CardEffect_Buff()
    {

    }

    public void CardEffect_BanishCards()
    {

    }

    public void CardEffect_MoveCards()
    {

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
