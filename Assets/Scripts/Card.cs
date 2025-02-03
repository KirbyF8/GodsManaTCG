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

   
    public List<ActivationType> activationTypes;
   

   
    public int[] cardEffect;



    public int[] effectHowMany;     
    public string[] effectTargetName; 
    public string[] effectCardClass;  
    public string[] effectCardDeity;  
    public int[] effectCost;           
    public int[] effectWhere;           
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
     int[] E_HowMany = null,
    string[] E_Name = null,
    string[] E_Class = null,
    string[] E_Deity = null,
    int[] E_Cost = null,
    int[] E_Where = null,
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

        effectHowMany = E_HowMany ?? new int[2] { 1, 1 };
        effectTargetName = E_Name ?? new string[2] { "", "" };
        effectCardClass = E_Class ?? new string[2] { "", "" };
        effectCardDeity = E_Deity ?? new string[2] { "", "" };
        effectCost = E_Cost ?? new int[2] { 0, 0 };
        effectWhere = E_Where ?? new int[2] { 0, 0 };
        effectATK = E_ATK ?? new int[2] { 0, 0 };
        effectDEF = E_DEF ?? new int[2] { 0, 0 };
        effectHP = E_HP ?? new int[2] { 0, 0 };
    }

    

}
