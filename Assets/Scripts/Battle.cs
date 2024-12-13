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

    private void Start()
    {
        SetRivalIcon();
        HideDmgs();




        attackerDC.updateDisplay(attackerDC.cardId);
        //defenderDC.updateDisplay(defenderDC.cardId);

        HideDefenderPlayerCard();
        ShowNoDefenderIcon();
        StartCoroutine(Anim2(true));
    }

    private void SetRivalIcon()
    {
        iconRival = iconRivalArray[0];
        //TODO:
    }

    public void battle(Card attacker, Card defender, bool atackerPlayer)
    {
        battlePanel.SetActive(true);


        attackerDC.updateDisplay(attacker.cardId);

        if (defender == null || defender.cardId == 0)
        {
            HideDefenderPlayerCard();
            ShowNoDefenderIcon();
            StartCoroutine(Anim2(atackerPlayer));
        }
        else
        {

            ShowDefenderPlayerCard();
            HideNoDefenderIcon();
            defenderDC.updateDisplay(defender.cardId);
            
        }
       

        StartCoroutine(Anim());

    }

    private IEnumerator Anim()
    {
        ShowSword();
        swordRT.DOMoveX(swordEndPos, animationTime).SetEase(Ease.Linear).OnComplete(HideSword);

        yield return new WaitForSeconds(0.6f);
        defenderDC.cardHpLosted(attackerDC.cardAttack);
        yield return new WaitForSeconds(2f);

        if (defenderDC.IAmAlive())
        {
            
            ShowShield();
            shieldRT.DOMoveX(shieldEndPos, animationTime).SetEase(Ease.Linear).OnComplete(HideShield);
            yield return new WaitForSeconds(0.6f);
            attackerDC.cardHpLosted(defenderDC.cardDefense);

            yield return new WaitForSeconds(1f);
        }
        else
        {
            HideShield();
        }

        yield return new WaitForSeconds(2f);
        FinishBattle();

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
        damageAttacker.text = defenderDC.cardAttack.ToString();
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

    }
}
