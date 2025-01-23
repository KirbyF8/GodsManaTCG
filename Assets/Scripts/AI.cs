using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.Progress;

public class AI : MonoBehaviour
{

    [SerializeField] PlayerDeck aiDeck;
    [SerializeField] TurnManager turnManager;
 
    private List<Card> playableCards = new List<Card>();
    private List<GameObject> playableCardsGameObject = new List<GameObject>();

    public void SummonFase(List<GameObject> card)
    {
        playableCardsGameObject = card;
        foreach (var item in card)
        {
            DisplayCard aux = item.GetComponent<DisplayCard>();
            if (aiDeck.CanPlayCardAI(aux.GetThisCard()))
            {

                playableCards.Add(aux.GetThisCard());
                
            }
            
        }

        if (playableCards == null || playableCards.Count <= 0)
        {
           
            turnManager.NextFase();
            return;
        }

        StartCoroutine(PlayCard());
    }


    private GameObject playedCardGameObject;
    private IEnumerator PlayCard()
    {
        yield return new WaitForSeconds(1);
        Card playedCard = playableCards[Random.Range(0, playableCards.Count)];
        aiDeck.PlayCard(playedCard);
        foreach (var item in playableCardsGameObject)
        {
            DisplayCard aux = item.GetComponent<DisplayCard>();
            if (playedCard == aux.GetThisCard())
            {
                playedCardGameObject = item;
            }

        }
        aiDeck.hand.Remove(playedCardGameObject);
        aiDeck.ConfirmDestruction();
        DisplayCard aux2 = playedCardGameObject.GetComponent<DisplayCard>();
        aux2.Destruction();
        ResetPlayableCards();
        aiDeck.AiTurn();
    }

    private void ResetPlayableCards()
    {
        playableCards.Clear();
    }
}
