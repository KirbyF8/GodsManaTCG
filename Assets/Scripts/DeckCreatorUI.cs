using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeckCreator : MonoBehaviour
{

    public List<Card> cardOnDeck = new List<Card>();

    private int actualPage = 1;
    private const int maxPages = 26;
    //? ---- Cambiar esto por formula ---

    [SerializeField] DisplayCard[] cards;
    [SerializeField] private TextMeshProUGUI[] text;
    [SerializeField] DeckPersistance deckPersistance;

    [SerializeField] TMPro.TMP_InputField inputDeckName;
    [SerializeField] GameObject cardInDeck;
    [SerializeField] GameObject cardInDeckBox;

    [SerializeField] GameObject deckInSaves;


    void Start()
    {
        
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].WhereIAm(0);
        }

    }

   
    public void AddCardToDeck(int card)
    {
        int cardNumber = 0;
        for (int i = 0; i < cardOnDeck.Count; i++)
        {
            if (cards[card].cardName == cardOnDeck[i].cardName)
            {
                cardNumber++;
            }
        }

        if (cardNumber <= 2 && deckPersistance.NumberOfCards(cards[card].returnCard()) > cardNumber )
        {
            cardOnDeck.Add(cards[card].returnCard());


            
            GameObject clone = Instantiate(cardInDeck);
            clone.GetComponent<CardInDeckCreator>().updateInfoCard(cards[card].cardName, cards[card].cardCost, cards[card].cardType);
            clone.transform.SetParent(cardInDeckBox.transform, false);
            
        }

    }

    public void RemoveCardFromDeck(string cardName)
    {
        for (int i = 0; i < cardOnDeck.Count; i++)
        {
            if (cardOnDeck[i].cardName == cardName)
            {
                cardOnDeck.Remove(cardOnDeck[i]);
                return;
            }
        }
    }

    string deckName;
    public void SaveDeck()
    {
        
        deckName = inputDeckName.text;
        if (deckName == "" || deckName == null || cardOnDeck.Count <= 20 || cardOnDeck.Count >= 81)
        {
            Debug.LogError("No has puesto nombre al Deck// Deck No válido");
        }
        else
        {
            deckPersistance.SaveDeck(cardOnDeck, deckName);
        }
        

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
                    cards[i].UpdateDisplay(aux1);
                    
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
                    cards[i].UpdateDisplay(aux2);

                    text[i].text = "X" + deckPersistance.NumberOfCards(cards[i].returnCard()).ToString();
                }

            }
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
