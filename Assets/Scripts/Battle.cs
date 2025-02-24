using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    [SerializeField] private GameObject battlePanel;

    [SerializeField] DisplayCard attackerDC;
    [SerializeField] DisplayCard defenderDC;

    [SerializeField] Transform attackerT;
    [SerializeField] Transform defenderT;

    [SerializeField] GameObject swordGO;
   
    [SerializeField] RectTransform swordRT;

    [SerializeField] GameObject shieldGO;
    [SerializeField] RectTransform shieldRT;

    
    [SerializeField] float swordEndPos;

    
    [SerializeField] float shieldEndPos;

    private float animationTime = 0.6f;

    [SerializeField] TMP_Text damageDefender;
    [SerializeField] TMP_Text damageAttacker;
    [SerializeField] GameObject damageDefenderGO;
    [SerializeField] GameObject damageAttackerGO;

    [SerializeField] TurnManager turnManager;
    [SerializeField] TMP_Text defenderPlayerHealth;
    [SerializeField] GameObject defenderCard;
    [SerializeField] GameObject noDefenderIcon;

    [SerializeField] Image Icon;
    [SerializeField] Sprite iconPlayer;
    [SerializeField] Sprite iconRival;
    [SerializeField] Sprite[] iconRivalArray;

    private DisplayCard displayCardAttacker;
    private DisplayCard displayCardDefender;

    [SerializeField] PlayerDeck playerDeck;
    [SerializeField] PlayerDeck rivalDeck;

    private List<GameObject> cardsToDelete = new List<GameObject>();

    private bool theBattlehasFinished = true;

    private void Start()
    {
        SetRivalIcon();
        HideDmgs();
      

    }

    public bool GetBattleHasFinished()
    {
        return theBattlehasFinished;
    }

    private void SetRivalIcon()
    {
        iconRival = iconRivalArray[0];
        //TODO:
    }


    private Card cardAttacker;
    private Card cardDefender;
    public void battle(DisplayCard attacker, bool atackerPlayer, DisplayCard defender = null)
    {
        Debug.Log("Entro en batalla");
        theBattlehasFinished = false;

        displayCardAttacker = attacker;
        
        displayCardDefender = null;
        if (defender != null )
        {
            displayCardDefender = defender;
            cardDefender = displayCardDefender.GetThisCard();
        }
      
        
        cardAttacker = displayCardAttacker.GetThisCard();
        

        battlePanel.SetActive(true);


        attackerDC.UpdateDisplay(cardAttacker.cardId);
        attackerDC.UpdateHealthForBattle(displayCardAttacker.ReturnHealth());

        if (displayCardDefender == null)
        {
            HideDefenderPlayerCard();
            ShowNoDefenderIcon();
            StartCoroutine(Anim2(atackerPlayer));
        }
        else
        {

            ShowDefenderPlayerCard();
            HideNoDefenderIcon();
            defenderDC.UpdateDisplay(cardDefender.cardId);
            defenderDC.UpdateHealthForBattle(displayCardDefender.ReturnHealth());
            StartCoroutine(Anim());

        }
       

        

    }

    private IEnumerator Anim()
    {
        ShowSword();
        swordRT.DOMoveX(swordEndPos, animationTime).SetEase(Ease.Linear).OnComplete(HideSword);

        yield return new WaitForSeconds(0.6f);
        displayCardDefender.cardHpLosted(attackerDC.cardAttack);
        defenderDC.UpdateHealthForBattle(displayCardDefender.ReturnHealth());
        yield return new WaitForSeconds(2f);
        
        if (displayCardDefender.IAmAlive())
        {
            
            ShowShield();
            shieldRT.DOMoveX(shieldEndPos, animationTime).SetEase(Ease.Linear).OnComplete(HideShield);
            yield return new WaitForSeconds(0.6f);
            displayCardAttacker.cardHpLosted(defenderDC.cardDefense);
            attackerDC.UpdateHealthForBattle(displayCardAttacker.ReturnHealth());

            yield return new WaitForSeconds(1f);
            if (!displayCardAttacker.IAmAlive())
            {
                if (turnManager.isYourTurn)
                {
                    rivalDeck.AddToGraveYard(displayCardAttacker.GetThisCard());
                    rivalDeck.field.Remove(displayCardAttacker.GetThisGameObject());
                }
                else
                {
                    playerDeck.AddToGraveYard(displayCardAttacker.GetThisCard());
                    playerDeck.field.Remove(displayCardAttacker.GetThisGameObject());
                }
                Debug.Log("Destruyendo Atacante");
                displayCardAttacker.DestroySelf();
            }
        }
        else
        {
            
            if (turnManager.isYourTurn)
            {
                Debug.Log(turnManager.isYourTurn);
                rivalDeck.AddToGraveYard(displayCardDefender.GetThisCard());
                
                rivalDeck.field.Remove(displayCardDefender.GetThisGameObject());
                displayCardDefender.DestroySelf();

            }
            else
            {
                playerDeck.AddToGraveYard(displayCardDefender.GetThisCard());
                displayCardDefender.Kill();
                Debug.Log("carta eliminada");
                cardsToDelete.Add(displayCardDefender.GetThisGameObject());
                //playerDeck.field.Remove(displayCardDefender.GetThisGameObject());
            }
            //

        }

        yield return new WaitForSeconds(1f);
        FinishBattle();

    }

    public void DestroyAllDefeatedCards()
    {
       
        if (cardsToDelete.Count > 0)
        {
           
           
            foreach (var card in cardsToDelete)
            {
                Debug.Log("antes quedaban estas cartas: " + playerDeck.field.Count);
                playerDeck.field.Remove(card);
                Debug.Log("quedan estas cartas: " + playerDeck.field.Count);
                DisplayCard cardDisplay = card.GetComponent<DisplayCard>();
                cardDisplay.DestroySelf();
            }
        }
        cardsToDelete.Clear();
    }

    private IEnumerator Anim2(bool atackerPlayer)
    {
        
        ShowSword();
        ShowDefenderPlayerHealth(atackerPlayer);
        ShowIcon(atackerPlayer);
        swordRT.DOMoveX(swordEndPos, animationTime).SetEase(Ease.Linear).OnComplete(HideSword);
        turnManager.ChangeLP(attackerDC.cardAttack, atackerPlayer);
        yield return new WaitForSeconds(0.6f);
        ShowDefenderPlayerHealth(atackerPlayer);
 
        yield return new WaitForSeconds(2f);
        FinishBattle();

    }

    private void ShowIcon(bool attackerPlayer)
    {
        if (attackerPlayer)
        {
            Icon.sprite = iconRival;
        }
        else 
        {
            Icon.sprite = iconPlayer;
        }
    }

    private void ShowDefenderPlayerHealth(bool attackerPlayer)
    {
        int aux = turnManager.ReturnPlayerHealth(attackerPlayer);
        defenderPlayerHealth.text = aux.ToString();
    }
    private void ShowNoDefenderIcon()
    {
        noDefenderIcon.SetActive(true);
    }
    private void HideNoDefenderIcon()
    {
        noDefenderIcon.SetActive(false);
    }
    private void ShowDefenderPlayerCard()
    {
        defenderCard.SetActive(true);
    }
    private void HideDefenderPlayerCard()
    {
        defenderCard.SetActive(false);
    }

    private void HideSword()
    {
        swordGO.SetActive(false);
        AtackerDealDamage();
    }

    private void ShowSword()
    {
        swordGO.SetActive(true);
    }

    private void HideShield()
    {
        shieldGO.SetActive(false);
        if (defenderDC.IAmAlive())
        {
            DefenderDealDamage();
        }
        
    }


    private void ShowShield()
    {
        shieldGO.SetActive(true);
    }

    private void AtackerDealDamage()
    {
        damageDefenderGO.SetActive(true);
        damageDefender.text = attackerDC.cardAttack.ToString();
        StartCoroutine(DamageAnim(damageDefenderGO));

    }

    private void DefenderDealDamage()
    {
        damageAttackerGO.SetActive(true);
        damageAttacker.text = defenderDC.cardDefense.ToString();
        StartCoroutine(DamageAnim(damageAttackerGO));
    }

    private IEnumerator DamageAnim(GameObject damage)
    {
        yield return new WaitForSeconds(1f);
        damage.SetActive(false );
        yield return new WaitForSeconds(0.5f);
    }

    private void HideDmgs()
    {
        damageDefenderGO.SetActive(false);
        damageAttackerGO.SetActive(false);
    }

    private void FinishBattle()
    {
        battlePanel.SetActive(false);
        turnManager.ResetBattle();
        ResetThisBattle();
        theBattlehasFinished = true;
        
    }

    private void ResetThisBattle()
    {
        displayCardAttacker = null; displayCardDefender = null; cardAttacker = null; cardDefender = null; 
    }
}
