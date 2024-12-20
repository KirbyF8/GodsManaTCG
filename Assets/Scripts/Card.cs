using System;
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
    //? 11 Da�ar
    public int[] cardEffect;



    public int[] effectCantidad;     
    public string[] effectTargetName; 
    public string[] effectCardClass;  
    public string[] effectCardDeity;  
    public int[] effectCoste;           
    public int[] effectDonde;           
    public int[] effectATK;            
    public int[] effectDEF;            
    public int[] effectHP;





    public Card(
     int Id,
     string CardName,
     int Cost,
     int Attack,
     int Defense,
     int Health,
     string Description,
     string Type,
     string Class,
     int Rarity,
     List<ActivationType> ActivationType = null,
     int[] Effect = null,
     int[] E_Cantidad = null,
    string[] E_Name = null,
    string[] E_Class = null,
    string[] E_Deity = null,
    int[] E_Coste = null,
    int[] E_Donde = null,
    int[] E_ATK = null,
    int[] E_DEF = null,
    int[] E_HP = null
 )
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

        cardEffect = Effect ?? new int[2] {0,0};

        effectCantidad = E_Cantidad ?? new int[2] { 1, 1 };
        effectTargetName = E_Name ?? new string[2] { "", "" };
        effectCardClass = E_Class ?? new string[2] { "", "" };
        effectCardDeity = E_Deity ?? new string[2] { "", "" };
        effectCoste = E_Coste ?? new int[2] { 0, 0 };
        effectDonde = E_Donde ?? new int[2] { 0, 0 };
        effectATK = E_ATK ?? new int[2] { 0, 0 };
        effectDEF = E_DEF ?? new int[2] { 0, 0 };
        effectHP = E_HP ?? new int[2] { 0, 0 };
    }

    

}
