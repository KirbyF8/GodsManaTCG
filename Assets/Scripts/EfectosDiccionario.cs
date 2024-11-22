using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosDiccionario : MonoBehaviour
{

    public enum ActivationType
    {
        OnEnterField,
        OnLeaveField,
        OncePerTurn,
        OnAttack,
        OnDefense,
        OnStartTurn,
        OnEndTurn,
        OnDestroyCard,
        OnStartBattle,
        OnEndBattle
    }

    public class CardActivator
    {
        private Dictionary<ActivationType, Action<Card>> activationActions;

        public CardActivator()
        {
            
            activationActions = new Dictionary<ActivationType, Action<Card>>
        {
            { ActivationType.OnEnterField, ActivateOnEnterField },
            { ActivationType.OnLeaveField, ActivateOnLeaveField },
            { ActivationType.OncePerTurn, ActivateOncePerTurn },
            { ActivationType.OnAttack, ActivateOnAttack },
            { ActivationType.OnDefense, ActivateOnDefense },
            { ActivationType.OnStartTurn, ActivateOnStartTurn },
            { ActivationType.OnEndTurn, ActivateOnEndTurn },
            { ActivationType.OnDestroyCard, ActivateOnDestroyCard },
            { ActivationType.OnStartBattle, ActivateOnStartBattle }, 
            { ActivationType.OnEndBattle, ActivatieOnEndBattle }
        };
        }

       
        public void ActivateEffect(ActivationType activationType, Card card)
        {
            if (activationActions.TryGetValue(activationType, out var activationAction))
            {
                activationAction(card);
            }
            else
            {
                Debug.Log("No se encontró la lógica de este tipo de activación.");
            }
        }

        
        private void ActivateOnEnterField(Card card)
        {
            Debug.Log($"Efecto activado al entrar al campo de la carta {card.cardName}.");
            
        }

        private void ActivateOnLeaveField(Card card)
        {
            Debug.Log($"Efecto activado al salir del campo de la carta {card.cardName}.");
            
        }

        private void ActivateOncePerTurn(Card card)
        {
            Debug.Log($"Efecto activado una vez por turno de la carta {card.cardName}.");
            
        }

        private void ActivateOnAttack(Card card)
        {
            Debug.Log($"Efecto activado al atacar con la carta {card.cardName}.");
            
        }

        private void ActivateOnDefense(Card card)
        {
            Debug.Log($"Efecto activado al defenderse con la carta {card.cardName}.");
           
        }

        private void ActivateOnStartTurn(Card card)
        {
            Debug.Log($"Efecto activado al inicio del turno de la carta {card.cardName}.");
        }

        private void ActivateOnEndTurn(Card card)
        {
            Debug.Log($"Efecto activado al final del turno de la carta {card.cardName}.");
        }

        private void ActivateOnDestroyCard(Card card)
        {
            Debug.Log($"Efecto activado al destuir la carta {card.cardName}.");
        }

        private void ActivateOnStartBattle(Card card)
        {
            Debug.Log($"Efecto activado al inicio de la fase de batalla de la carta {card.cardName}.");
        }

        private void ActivatieOnEndBattle(Card card)
        {
            Debug.Log($"Efecto activado al final de la fase de batalla turno de la carta {card.cardName}.");
        }
    }












    public class EffectParams
    {
        public int Cantidad { get; set; }
        public string CardName { get; set; }
        public string CardClass { get; set; }
        public string CardDeity { get; set; }
        public int Coste { get; set; }
        public int Donde { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int HP { get; set; }
    }

    public enum EffectType
    {
        DrawCards,
        DestroyCards,
        BanishCards,
        LookCards,
        BuffCards,
        HealDamageCards,
        Taunt,
        ManaChanges,
        LimitCards,
        Constants
    }

    public class DictionaryCardEffects
    {
        private Dictionary<int, Action<EffectParams>> effectActions;
        private CardEffects cardEffects;

        public DictionaryCardEffects()
        {
            cardEffects = new CardEffects();

            // Inicializa el diccionario con las funciones que encapsulan los efectos
            effectActions = new Dictionary<int, Action<EffectParams>>
        {

            { 1, cardEffects.CardEffect_DrawCards },
            { 2, cardEffects.CardEffect_DestroyCards },
            { 3, cardEffects.CardEffect_BanishCards },
            { 4, cardEffects.CardEffect_LookCards },
            { 5, cardEffects.CardEffect_BuffCards },
            { 6, cardEffects.CardEffect_HealDamageCards },
            { 7, cardEffects.CardEffect_Taunt },
            { 8, cardEffects.CardEffect_ManaChanges },
            { 9, cardEffects.CardEffect_LimitCards },
            {10, cardEffects.CardEffect_Constants },
            {11, cardEffects.CardEffect_SummonChosen },
            {12, cardEffects.CardEffect_RetreatChosenDeck },
            {13, cardEffects.CardEffect_RetreatChosenHand}


                
            
        };
        }

        public void ActivateEffect(int cardActivationEffect, EffectParams parameters)
        {
            
            if (effectActions.TryGetValue(cardActivationEffect, out var effectAction))
            {
                effectAction(parameters);
            }
            else
            {
                Debug.LogError("No hay efecto");
            }
        }
    }


    public class CardEffects
    {
        public void CardEffect_DrawCards(EffectParams parameters)
        {
            Console.WriteLine($"Draw");
            
        }

        public void CardEffect_DestroyCards(EffectParams parameters)
        {
            Console.WriteLine($"Destroy");
            
        }

        public void CardEffect_BanishCards(EffectParams parameters)
        {
            Console.WriteLine($"Banish");
            
        }

        public void CardEffect_LookCards(EffectParams parameters)
        {
            Console.WriteLine($"Look");
            
        }

        public void CardEffect_BuffCards(EffectParams parameters)
        {
            Console.WriteLine($"Buff");
           
        }

        public void CardEffect_HealDamageCards(EffectParams parameters)
        {
            Console.WriteLine($"Heal/Damage");
            
        }

        public void CardEffect_Taunt(EffectParams parameters)
        {
            Console.WriteLine($"Taunt");
            
        }

        public void CardEffect_ManaChanges(EffectParams parameters)
        {
            Console.WriteLine($"Mana");
            
        }

        public void CardEffect_LimitCards(EffectParams parameters)
        {
            Console.WriteLine($"Mana");
            
        }

        public void CardEffect_Constants(EffectParams parameters)
        {
            Console.WriteLine($"Mana");
            
        }

        public void CardEffect_SummonChosen(EffectParams parameters)
        {
            Console.WriteLine($"Summon");
        }

        public void CardEffect_RetreatChosenDeck(EffectParams parameters)
        {
            Console.WriteLine($"RetratDeck");
        }
        public void CardEffect_RetreatChosenHand(EffectParams parameters)
        {
            Console.WriteLine($"RetratHand");
        }
    }
}
