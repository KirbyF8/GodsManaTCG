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
        OnDestryCard,
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
            { ActivationType.OnStartTurn, ActivateOnStartTurn }
        };
        }

        // Método para ejecutar una activación
        public void ActivateEffect(ActivationType activationType, Card card)
        {
            if (activationActions.TryGetValue(activationType, out var activationAction))
            {
                activationAction(card);
            }
            else
            {
                Console.WriteLine("No se encontró la lógica para este tipo de activación.");
            }
        }

        // Métodos individuales para cada tipo de activación
        private void ActivateOnEnterField(Card card)
        {
            Console.WriteLine($"Efecto activado al entrar al campo para la carta {card.cardName}.");
            // Lógica específica para el efecto "OnEnterField"
        }

        private void ActivateOnLeaveField(Card card)
        {
            Console.WriteLine($"Efecto activado al salir del campo para la carta {card.cardName}.");
            // Lógica específica para el efecto "OnLeaveField"
        }

        private void ActivateOncePerTurn(Card card)
        {
            Console.WriteLine($"Efecto activado una vez por turno para la carta {card.cardName}.");
            // Lógica específica para el efecto "OncePerTurn"
        }

        private void ActivateOnAttack(Card card)
        {
            Console.WriteLine($"Efecto activado al atacar con la carta {card.cardName}.");
            // Lógica específica para el efecto "OnAttack"
        }

        private void ActivateOnDefense(Card card)
        {
            Console.WriteLine($"Efecto activado al defenderse con la carta {card.cardName}.");
            // Lógica específica para el efecto "OnDefense"
        }

        private void ActivateOnStartTurn(Card card)
        {

        }

        private void ActivateOnEndTurn(Card card)
        {

        }

        private void ActivationOnDestroyCard(Card card)
        {

        }

        private void ActivationOnStartBattle(Card card)
        {

        }

        private void ActivationOnEndBattle(Card card)
        {

        }
    }











    public class CardEffects
    {
        public void CardEffect_DrawCards(EffectParams parameters)
        {
            Console.WriteLine($"Draw");
            // Lógica para dibujar cartas
        }

        public void CardEffect_DestroyCards(EffectParams parameters)
        {
            Console.WriteLine($"Destroy");
            // Lógica para destruir cartas
        }

        public void CardEffect_BanishCards(EffectParams parameters)
        {
            Console.WriteLine($"Banish");
            // Lógica para destruir cartas
        }

        public void CardEffect_LookCards(EffectParams parameters)
        {
            Console.WriteLine($"Look");
            // Lógica para destruir cartas
        }

        public void CardEffect_BuffCards(EffectParams parameters)
        {
            Console.WriteLine($"Buff");
            // Lógica para destruir cartas
        }

        public void CardEffect_HealDamageCards(EffectParams parameters)
        {
            Console.WriteLine($"Heal/Damage");
            // Lógica para destruir cartas
        }

        public void CardEffect_Taunt(EffectParams parameters)
        {
            Console.WriteLine($"Taunt");
            // Lógica para destruir cartas
        }

        public void CardEffect_ManaChanges(EffectParams parameters)
        {
            Console.WriteLine($"Mana");
            // Lógica para destruir cartas
        }

        public void CardEffect_LimitCards(EffectParams parameters)
        {
            Console.WriteLine($"Mana");
            // Lógica para destruir cartas
        }

        public void CardEffect_Constants(EffectParams parameters)
        {
            Console.WriteLine($"Mana");
            // Lógica para destruir cartas
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

    public class CardGame
    {
        private Dictionary<int, Action<EffectParams>> effectActions;
        private CardEffects cardEffects;

        public CardGame()
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
            {10, cardEffects.CardEffect_Constants }


                
            
        };
        }

        public void ActivateEffect(int cardActivationEffect, EffectParams parameters)
        {
            // Busca el efecto y lo ejecuta si existe
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
}
