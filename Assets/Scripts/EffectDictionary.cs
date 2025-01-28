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












  
}
