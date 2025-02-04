using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.Progress;

public class AI : MonoBehaviour
{

    [SerializeField] PlayerDeck aiDeck;
    [SerializeField] TurnManager turnManager;
    [SerializeField] PlayerDeck playerDeck;
 
    private List<Card> playableCards = new List<Card>();
    private List<GameObject> playableCardsGameObject = new List<GameObject>();
    
    private List<GameObject> attackableCards = new List<GameObject>();
    private List<GameObject> attackableCardsGameObject = new List<GameObject>();

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
        
        ResetPlayableCards();
        aiDeck.AiTurn();
    }

    private void ResetPlayableCards()
    {
        playableCards.Clear();
    }


    public void BattleFase(List<GameObject> card)
    {
        attackableCards.Clear();
        attackableCardsGameObject = card;
        foreach (var item in card)
        {
            
           if (!item.GetComponent<DisplayCard>().ThisCardHasAttacked()) 
            {
                attackableCards.Add(item);
            }

        }

        if (attackableCards == null || attackableCards.Count <= 0)
        {

            turnManager.NextFase();
            return;
        }

        StartCoroutine(CardAttack());
    }

    private IEnumerator CardAttack()
    {
        yield return new WaitForSeconds(1f);


        if (playerDeck.field.Count <= 0)
        {
            
            foreach (var item in attackableCards)
            {
                turnManager.selectAttackerFunc(item.GetComponent<DisplayCard>());
                turnManager.battle();
                Debug.Log("HOLA3");
                yield return new WaitForSeconds(0.5f);
            }
            StopCoroutine(CardAttack());

        }


        foreach (var item in attackableCards)
        {
            
            foreach (var item2 in playerDeck.field)
            {
                if (!item.GetComponent<DisplayCard>().ThisCardHasAttacked() && 
                    item.GetComponent<DisplayCard>().cardAttack >= (item2.GetComponent<DisplayCard>().cardHealth - item2.GetComponent<DisplayCard>().cardHpLost) ||
                    (item.GetComponent<DisplayCard>().cardHealth - item.GetComponent<DisplayCard>().cardHpLost) > item2.GetComponent<DisplayCard>().cardDefense)
                {
                    turnManager.selectAttackerFunc(item.GetComponent<DisplayCard>());
                    turnManager.selectDefenderFunc(item2.GetComponent<DisplayCard>());
                    turnManager.battle();
                    Debug.Log("HOLA2");

                }

                item.GetComponent<DisplayCard>().CardHasAttacked();
                Debug.Log("HOLA");
                yield return new WaitForSeconds(2f);
            }
        }

        aiDeck.AiBattle();
        
    }
}
