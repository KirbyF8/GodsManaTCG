using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class AI : MonoBehaviour
{

    [SerializeField] PlayerDeck aiDeck;
    [SerializeField] TurnManager turnManager;
    [SerializeField] PlayerDeck playerDeck;
 
    private List<Card> playableCards = new List<Card>();
    private List<GameObject> playableCardsGameObject = new List<GameObject>();
    
    private List<GameObject> attackableCards = new List<GameObject>();

    [SerializeField] private Battle battle;
   
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

    private bool firstBattle = true;
    public void BattleFase(List<GameObject> card)
    {
        attackableCards.Clear();
        if (firstBattle)
        {
            foreach (var item in card)
            {

                item.GetComponent<DisplayCard>().CardAttackReset();

            }
            firstBattle = false;
        }
       
        foreach (var item in card)
        {
            
           if (!item.GetComponent<DisplayCard>().ThisCardHasAttacked()) 
            {
                attackableCards.Add(item);
            }

        }

        if (attackableCards.Count <= 0)
        {
            StartCoroutine(ChangeTurn());
            
            
            return;
        }

        StartCoroutine(CardAttack());
    }
    private IEnumerator ChangeTurn()
    {
        
        yield return new WaitUntil(()=> turnManager.BattleHasFinished());
        firstBattle = true;
        
        turnManager.NextFase();
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
                item.GetComponent<DisplayCard>().CardHasAttacked();
                //Debug.Log("Ataque Directo");
                yield return new WaitForSeconds(2f);
            }
           

        }else { 

        
            foreach (var item in attackableCards)
            {
                DisplayCard displayCard = item.GetComponent<DisplayCard>();
                
               
                foreach (var playerCard in playerDeck.field)
                {
                    
                   
                    DisplayCard playerDisplay = playerCard.GetComponent<DisplayCard>();
                   
                    if (!displayCard.ThisCardHasAttacked() &&
                        playerDisplay.IAmAlive() &&
                        (displayCard.cardAttack >= (playerDisplay.cardHealth - playerDisplay.cardHpLost) ||
                        (displayCard.cardHealth - displayCard.cardHpLost) > playerDisplay.cardDefense))
                    {
                        turnManager.selectAttackerFunc(displayCard);
                        turnManager.selectDefenderFunc(playerDisplay);
                        turnManager.battle();
                        yield return new WaitForSeconds(2.5f);
                       

                    }
                   

                    
                    
                        
                    
                  //! EVENTO ON BATTLE  FINISH
                    yield return new WaitForSeconds(1f);
                
                }
                displayCard.CardHasAttacked();
                Debug.Log("Acabé con la coleccion");
            }
        }
        //turnManager.DestroyBattleCards();
        battle.DestroyAllDefeatedCards();
        aiDeck.AiBattle();
        
    }
}
