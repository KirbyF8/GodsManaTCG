using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public string cardClass;

   
    // Extra info
    public int cardRarity;

    //! 0 Nada
    //! 1 Al ser invocado
    //! 2 Al ser destruido
    //! 3 Al atacar
    //! 4 Al Ser Invocado + Al ser destruido
    //! 5 Al Ser Invocado + Al atacar
    //! 6 Al atacar + Al ser destruido
    //! 7 Al activar
    //! 8 Al ser atacado
    public int cardActivationEffect;
    
    //? 0 Nada
    //? 1 Robar
    //? 2 Destruir
    public int cardEffect;

    public Card()
    {

    }

    public Card(int Id, string CardName, int Cost, int Attack, int Defense, int Health, string Description, string Type, string Class, int Rarity, int ActivationEffect = 0 ,int Effect = 0)
    {
        cardId = Id;
        cardName = CardName;
        cardCost = Cost;
        cardAttack = Attack;
        cardDefense = Defense;
        cardHealth = Health;
        cardDescription = Description;
        cardType = Type;

        cardClass = Class;
        cardRarity = Rarity;
        cardEffect = Effect;

    }

    

}
