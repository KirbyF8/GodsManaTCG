using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static EfectosDiccionario;

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
    public List<ActivationType> activationTypes;
   

    //? 0 Nada
    //? 1 Buscar
    //? 2 Destruir
    //? 3 Robar
    //? 4 Invocar
    //? 5 Crear Fichas
    //? 6 Bufo
    //? 7 Desterrar 
    //? 8 Devolver
    //? 9 Curar
    //? 10 Mana
    //? 11 Dañar
    public int cardEffect;

    public int effectCantidad;   
    public string effectTargetName; 
    public string effectCardClass;  
    public string effectCardDeity;  
    public int effectCoste;        
    public int effectDonde;        
    public int effectATK;          
    public int effectDEF;
    public int effectHP;

    



    public Card(int Id, string CardName, int Cost, int Attack, int Defense, int Health, string Description, string Type, string Class, int Rarity, 
        List<ActivationType> ActivationType = null ,int Effect = 0, int E_Cantidad = 1, string E_Name = "", string E_Class = "", string E_Deity = "", int E_Coste = 0, 
        int E_Donde = 0, int E_ATK = 0, int E_DEF = 0, int E_HP = 0)
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


        activationTypes = ActivationType;

        cardEffect = Effect;

        effectCantidad = E_Cantidad;
        effectTargetName = E_Name;
        effectCardClass = E_Class;
        effectCardDeity = E_Deity;
        effectCoste = E_Coste;
        effectDonde = E_Donde;
        effectATK = E_ATK;
        effectDEF = E_DEF;
        effectHP = E_HP;
        effectHP = E_HP;
    }

    

}
