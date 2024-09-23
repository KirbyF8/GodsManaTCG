using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Card 
{

    public int cardId;
    public string cardName;
    public int cardCost;
    public int cardAttack;
    public int cardDefense;
    public int cardHealth;
    public string cardDescription;
    public string cardType;


    // Extra info
    public int cardTime;
    public int cardRarity;

    public Card()
    {

    }

    public Card(int Id, string CardName, int Cost, int Attack, int Defense, int Health, string Description, string Type, int Time, int Rarity)
    {
        cardId = Id;
        cardName = CardName;
        cardCost = Cost;
        cardAttack = Attack;
        cardDefense = Defense;
        cardHealth = Health;
        cardDescription = Description;
        cardType = Type;

        cardTime = Time;
        cardRarity = Rarity;


    }


}
