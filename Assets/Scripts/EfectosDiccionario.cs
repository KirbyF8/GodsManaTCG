using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosDiccionario : MonoBehaviour
{

    public class CardEffects
    {
        public void CardEffect_DrawCards(string player, int num1, string target, int num2, string deity, int num3)
        {
            Console.WriteLine($"Draw Cards effect activated for {player} with {num2} cards.");
            // Lógica de dibujar cartas
        }

        public void CardEffect_DestroyCards(string player, int num1, int targetCount, string type, string deity, int power)
        {
            Console.WriteLine($"Destroy Cards effect activated with target count: {targetCount} and power: {power}.");
            // Lógica de destruir cartas
        }
    }

    public class CardGame
    {
        private Dictionary<int, Action<string, int, string, int, string, int>> effectActions;
        private CardEffects cardEffects;

        public CardGame()
        {
            cardEffects = new CardEffects();

            // Asocia cada efecto con una lambda que encapsula el método específico
            effectActions = new Dictionary<int, Action<string, int, string, int, string, int>>
        {
            { 1, (player, num1, target, num2, deity, num3) => cardEffects.CardEffect_DrawCards(player, num1, target, num2, deity, num3) },
            { 2, (player, num1, target, num2, deity, num3) => cardEffects.CardEffect_DestroyCards(player, num1, num2, target, deity, num3) }
            // Agrega más efectos aquí de la misma manera
        };
        }

        public void ActivateEffect(int cardActivationEffect, string player, int num1, string target, int num2, string deity, int num3)
        {
            // Verifica si el efecto existe y lo ejecuta con los parámetros
            if (effectActions.TryGetValue(cardActivationEffect, out var effectAction))
            {
                effectAction(player, num1, target, num2, deity, num3);
            }
            else
            {
                Console.WriteLine("Efecto no definido para este número de activación.");
            }
        }
    }