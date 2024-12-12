using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

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

    private int damage = 10;

    private void Start()
    {
        HideSword();
        HideShield();
        HideDmgs();
        StartCoroutine("Anim");
    }


    public void battle(Card attacker, Card defender)
    {
        battlePanel.SetActive(true);

        attackerDC.updateDisplay(attackerDC.cardId);
        defenderDC.updateDisplay(defenderDC.cardId);

        StartCoroutine("Anim");

    }

    private IEnumerator Anim()
    {
        ShowSword();
        swordRT.DOMoveX(swordEndPos, animationTime).SetEase(Ease.Linear).OnComplete(HideSword).OnComplete(AtackerDealDamage);


        defenderDC.cardHpLosted(attackerDC.cardAttack);
        yield return new WaitForSeconds(2f);

        if (defenderDC.IAmAlive())
        {
            
            ShowShield();
            shieldRT.DOMoveX(shieldEndPos, animationTime).SetEase(Ease.Linear).OnComplete(HideShield).OnComplete(DefenderDealDamage);

            attackerDC.cardHpLosted(defenderDC.cardDefense);

            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForEndOfFrame();
        

    }

    private void HideSword()
    {
        swordGO.SetActive(false);
    }

    private void ShowSword()
    {
        swordGO.SetActive(true);
    }

    private void HideShield()
    {
        shieldGO.SetActive(false);
    }
    private void ShowShield()
    {
        shieldGO.SetActive(true);
    }

    private void ChangeAnimationTime(int newAnimTime)
    {
        animationTime = newAnimTime;
    }

    private void AtackerDealDamage()
    {
        damageDefenderGO.SetActive(true);
        damageDefender.text = damage.ToString();
        StartCoroutine(DamageAnim(damageDefenderGO));

    }

    private void DefenderDealDamage()
    {
        damageAttackerGO.SetActive(true);
        damageDefender.text = damage.ToString();
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
}
