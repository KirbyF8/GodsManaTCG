using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int cardId;
    public string cardName;
    public int cardCost;
    public int cardAttack;
    public int cardDefense;
    public int cardHealth;
    public string cardDescription;
    public string cardType;

   
    public string cardClass;
    // Extra info
    public int cardRarity;

    public TMP_Text nameText;
    public TMP_Text manaCostText;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text healthText;
    public TMP_Text descriptionText;
    public TMP_Text cardText;



    void Start()
    {
        displayCard[0] = CardDatabase.cardList[displayId];
        SetCard();
    }
 

    void SetCard()
    {
        cardId = displayCard[0].cardId;
        cardName = displayCard[0].cardName;
        cardCost = displayCard[0].cardCost;
        cardAttack = displayCard[0].cardAttack;
        cardDefense = displayCard[0].cardDefense;
        cardHealth = displayCard[0].cardHealth;
        cardDescription = displayCard[0].cardDescription;
        cardType = displayCard[0].cardType;
        cardClass = displayCard[0].cardClass;

        nameText.text = cardName;
        manaCostText.text = "" + cardCost;
        attackText.text = "" + cardAttack;
        defenseText.text = "" + cardDefense;
        healthText.text = "" + cardHealth;
        descriptionText.text = cardDescription;
        cardText.text = "" + cardClass;
    }
}
