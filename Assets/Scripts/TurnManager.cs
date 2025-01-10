using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class TurnManager : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurns;
    public int rivalTurns;

    public int maxManaYou = 0;
    public int yourActualMana = 0;
    public int maxManaRival = 0;
    public int rivalActualMana;



    [SerializeField] Sprite ManaN;
    [SerializeField] Sprite ManaN_Spent;

    [SerializeField] Sprite ManaDana;
    [SerializeField] Sprite ManaDana_Spent;

    [SerializeField] Sprite ManaEtse;
    [SerializeField] Sprite ManaEtse_Spent;

    [SerializeField] Sprite ManaMiknit;
    [SerializeField] Sprite ManaMiknit_Spent;

    [SerializeField] Sprite ManaChronos;
    [SerializeField] Sprite ManaChronos_Spent;

    [SerializeField] Sprite ManaMurgu;
    [SerializeField] Sprite ManaMurgu_Spent;

    [SerializeField] Sprite ManaYrys;
    [SerializeField] Sprite ManaYrys_Spent;

    [SerializeField] Image[] Manas;
    [SerializeField] Image[] RivalManas;

    [SerializeField] PlayerDeck playerDeck;
    [SerializeField] PlayerDeck rivalDeck;

    private int turnFase;


    [SerializeField] GameObject examineCardPanel;
    [SerializeField] GameObject examineCard;
    private Card examinedCardCard;

    private int yourLP;
    private int rivalLP;

    [SerializeField] GameObject battlePanel;
    
    [SerializeField] GameObject atackerGO;
    [SerializeField] GameObject defenderGO;

    [SerializeField] GameObject faseObject;
    [SerializeField] Image faseSprite;
    [SerializeField] Sprite summonSprite;
    [SerializeField] Sprite battleSprite;

    [SerializeField] Mana mana;
    [SerializeField] Mana rivalMana;

    private Card selectAttacker;
    private Card selectDefender;

    [SerializeField] Battle battleSC;

    private void Start()
    {
        yourLP = 50;
        rivalLP = 50;

        maxManaYou = 0;
        maxManaRival = 0;
        SetFase(0);
        TurnSelect();
        FirstDraw();
        StartTurn();
        
    }

    public void ExamineCard(Card card)
    {
        examineCardPanel.SetActive(true);
        
        DisplayCard cardDisplayCardComponent = examineCard.GetComponent<DisplayCard>();

        examinedCardCard = card;
        cardDisplayCardComponent.updateDisplay(examinedCardCard.cardId);
        cardDisplayCardComponent.WhereIAm(6);

    }

    public void ExitExamineCard()
    {
        examineCardPanel.SetActive(false);
    }

    public PlayerDeck returnRivalDeck()
    {
        return rivalDeck;
    }

    public PlayerDeck returnPlayerDeck()
    {
        return playerDeck;
    }
  
    public void DrawCard()
    {
        if (isYourTurn)
        {
            playerDeck.CallDraw(1);
            SetFase(1);
            return;
        }
        else if (!isYourTurn)
        {
            rivalDeck.CallDraw(1);
            SetFase(1);
            return;
        }

    }

    private void FirstDraw()
    {
        playerDeck.CallDraw(6);
        rivalDeck.CallDraw(6);
        SetFase(1);
    }

    private bool ItsFirstTurn()
    {
        if (yourTurns == 0 && rivalTurns == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void StartTurn()
    {
        if (isYourTurn)
        {
            //TODO
            maxManaYou++;
            if (maxManaYou >= 10)
                {
                    maxManaYou = 10;
                }
                
            yourActualMana = maxManaYou;
            if (!ItsFirstTurn())
                {
                    DrawCard();
                }
            ManaChanges("N", 0);
            ManaChanges("N", 1);
            yourTurns++;
            SetFase(1);
           
        }

        if (!isYourTurn)
        {
            maxManaRival++;
            if (maxManaRival >= 10)
            {
                maxManaRival = 10;
            }
           
            rivalActualMana = maxManaRival;
            if (!ItsFirstTurn())
            {
                DrawCard();
            }
            ManaChanges("N", 0);
            ManaChanges("N", 1);

            isYourTurn = false;




            rivalTurns++;
            SetFase(1);

        }

    }

    private void TurnSelect()
    {

        int coin = 1; 
        // int coin = Random.Range(0, 2);
       
        if (coin == 1)
        {
            isYourTurn = true;

        }
        else
        {
            isYourTurn = false;

        }

    }

    public void EndTurn()
    {
        if (isYourTurn)
        {
            
            
            isYourTurn = false;
            SetFase(0);

        }
        else if (!isYourTurn)
        {
           
            
            isYourTurn = true;
            SetFase(0);
        }

        StartTurn();
    }
    public void NextFase()
    {
        turnFase++;

        

        if (turnFase >= 3)
        {
            EndTurn();
        }

        if (turnFase == 1)
        {
            faseSprite.sprite = summonSprite;
        }
        else
        {
            faseSprite.sprite = battleSprite;
        }

        if (isYourTurn)
        {
            faseObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            faseObject.transform.rotation = new Quaternion(180, 0, 0, 0);
        }
    }
    public void SetFase(int fase)
    {
        turnFase = fase;
        
    }

    public bool CanSummonFase()
    {
        if (turnFase == 1 && isYourTurn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    // !0 Add new mana
    //? 1 Restore Mana
    //! 2 Spend Mana
    public void ManaChanges(string god, int operation, int manaSpent = 0)
    {
        int aux;
        int aux2;
        
        if (isYourTurn)
        {
           
            aux = maxManaYou;
            aux2 = yourActualMana;

        }
        else
        {
            aux = maxManaRival;
            aux2 = rivalActualMana;

        }


        aux = aux - 1;

        if (operation == 0)
        {

            if (isYourTurn)
            {
                mana.AddManas(god, aux);

            }
            else if (!isYourTurn)
            {
                rivalMana.AddManas(god, aux);
            }

            return;
        }

        if (operation == 1)
        {
            if (isYourTurn)
            {
                mana.RestoreManas(aux);

            } else if (!isYourTurn)
            {
                rivalMana.RestoreManas(aux);
            }
           
            return;
        }

        if (operation == 2)
        {
           if (isYourTurn)
            {
               
                yourActualMana -= manaSpent;
               
                mana.SpendManas(god, aux2, yourActualMana);

            }else if (!isYourTurn)
            {
                rivalActualMana -= manaSpent;
                rivalMana.SpendManas(god, aux2, rivalActualMana);
            }
            return;
          }
}
    

    public bool checkMana(string god, int cardCost)
    {
        if (isYourTurn) 
        {
            if (cardCost <= yourActualMana)
            {
                
                ManaChanges(god, 2, cardCost);

                return true;
            }

        }
        else if (!isYourTurn)
        {
            if (cardCost <= rivalActualMana)
            {
               
                ManaChanges(god, 2, cardCost);
                return true;
            }
        }
        

        
        return false;
    }


    public int ReturnPlayerHealth(bool player)
    {
        if (player)
        {
            return rivalLP;
        }
        else
        {
            return yourLP;
        }
    }

    public void ChangeLP(int dmg, bool player)
    {
        if (player)
        {
            rivalLP -= dmg;
        }
        else
        {
            yourLP -= dmg;
        }
    }

    public void selectAttackerFunc(Card card)
    {
        selectAttacker = card;
    }

    public void selectDefenderFunc(Card card)
    {
        selectDefender = card;
    }

    public void battle()
    {


        battlePanel.SetActive(true);

        battleSC.battle(selectAttacker, selectDefender, isYourTurn);


    }

 
    
}
   


        
    

