using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckCreator : MonoBehaviour
{

    public List<Card> cardOnDeck = new List<Card>();

    private int actualPage = 1;
    private const int maxPages = 23;

    [SerializeField] DisplayCard[] cards;
    [SerializeField] private TextMeshProUGUI[] text;
    [SerializeField] DeckPersistance deckPersistance;

    private Card auxCard;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].WhereIAm(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //? Dir 0 <-
    //? Dir 1 ->
    public void changeCards(int dir)
    {
        if (dir == 0)
        {
            if (actualPage == 1)
            {
                return;
            }
            else
            {
                actualPage--;
                for (int i = 0; i < cards.Length; i++)
                {
                    int aux1 = cards[i].displayId -= 6;
                    cards[i].updateDisplay(aux1);
                    
                    text[i].text = "X" + deckPersistance.NumberOfCards(cards[i].returnCard()).ToString();
                }
                
            }
        }
        if (dir == 1)
        {
            if (actualPage == maxPages)
            {
                return;
            }
            else
            {
                
                actualPage++;
                for (int i = 0; i < cards.Length; i++)
                {
                    
                    int aux2 = cards[i].displayId += 6;
                    cards[i].updateDisplay(aux2);

                    text[i].text = "X" + deckPersistance.NumberOfCards(cards[i].returnCard()).ToString();
                }

            }
        }
    }

    public void addCardToDeck(Card card)
    {
        int cardNumber = 0;
        for (int i = 0;i < cardOnDeck.Count;i++) 
        {
         if (card.cardName == cardOnDeck[i].cardName)
            {
                cardNumber++;
            }
        }

        if (cardNumber <= 2)
        {
            cardOnDeck.Add(card);
        }
        
    }

}
