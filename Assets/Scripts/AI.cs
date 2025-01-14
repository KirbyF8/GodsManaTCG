using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    [SerializeField] PlayerDeck aiDeck;
    [SerializeField] TurnManager turnManager;
 
    private List<Card> playableCards;
    

    public void SummonFase(List<Card> card)
    {
        foreach (Card item in card)
        {
            if (aiDeck.CanPlayCardAI(item))
            {
                playableCards.Add(item);
            }
            
        }

        if (playableCards == null || playableCards.Count <= 0)
        {
            turnManager.NextFase();
        }
    }



    private IEnumerator playCard()
    {
        yield return new WaitForSeconds(1);

        aiDeck.PlayCard(playableCards[Random.Range(0, playableCards.Count + 1)]);

        ResetPlayableCards();
        aiDeck.AiTurn();
    }

    private void ResetPlayableCards()
    {
        playableCards.Clear();
    }
}
