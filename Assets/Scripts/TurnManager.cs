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

    private void Start()
    {
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
           
                if (maxManaYou >= 10)
                {
                    maxManaYou = 10;
                }
                maxManaYou++;
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
            if (maxManaRival >= 10)
            {
                maxManaRival = 10;
            }
            maxManaRival++;
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
                YourAddMana(god, aux, Manas);

            }
            else if (!isYourTurn)
            {
                RivalAddMana(god, aux, RivalManas);
            }

            return;
        }

        if (operation == 1)
        {
            if (isYourTurn)
            {
                YourRestoreManas(aux,  Manas);

            } else if (!isYourTurn)
            {
                RivalRestoreManas(aux, RivalManas);
            }
           
            return;
        }

        if (operation == 2)
        {
           if (isYourTurn)
            {
               
                yourActualMana -= manaSpent;
               
                yourSpendManas(god, aux2, Manas);

            }else if (!isYourTurn)
            {
                rivalActualMana -= manaSpent;
                rivalSpendManas(god, aux2, RivalManas);
            }
            return;
          }
}
    private void YourAddMana(string god, int aux,  Image[] Manas)
    {
        if (god == "N")
        {
            Manas[aux].sprite = ManaN;
        }
        else if (god == "Dana")
        {
            Manas[aux].sprite = ManaDana;
        }
        else if (god == "Etse")
        {
            Manas[aux].sprite = ManaEtse;
        }
        else if (god == "Miknit")
        {
            Manas[aux].sprite = ManaMiknit;
        }
        else if (god == "Chronos")
        {
            Manas[aux].sprite = ManaChronos;
        }
        else if (god == "Murgu")
        {
            Manas[aux].sprite = ManaMurgu;
        }
        else if (god == "Yrys")
        {
            Manas[aux].sprite = ManaYrys;
        }
    }

    private void RivalAddMana(string god, int aux, Image[] RivalManas)
    {
        if (god == "N")
        {
            RivalManas[aux].sprite = ManaN;
        }
        else if (god == "Dana")
        {
            RivalManas[aux].sprite = ManaDana;
        }
        else if (god == "Etse")
        {
            RivalManas[aux].sprite = ManaEtse;
        }
        else if (god == "Miknit")
        {
            RivalManas[aux].sprite = ManaMiknit;
        }
        else if (god == "Chronos")
        {
            RivalManas[aux].sprite = ManaChronos;
        }
        else if (god == "Murgu")
        {
            RivalManas[aux].sprite = ManaMurgu;
        }
        else if (god == "Yrys")
        {
            RivalManas[aux].sprite = ManaYrys;
        }
    }
    private void YourRestoreManas(int aux, Image[] Manas)
    {

        for (int i = 0; i <= aux; i++)
        {


            if (Manas[i].sprite.name == "ManaDeDana_Agotado")
            {
                Manas[i].sprite = ManaDana;
            }
            else if (Manas[i].sprite.name == "ManaDeEtse_Agotado")
            {
                Manas[i].sprite = ManaEtse;
            }
            else if (Manas[i].sprite.name == "ManaDeMiknit_Agotado")
            {
                Manas[i].sprite = ManaMiknit;
            }
            else if (Manas[i].sprite.name == "ManaDeChronos_Agotado")
            {
                Manas[i].sprite = ManaChronos;
            }
            else if (Manas[i].sprite.name == "ManaDeMurgu_Agotado")
            {
                Manas[i].sprite = ManaMurgu;
            }
            else if (Manas[i].sprite.name == "ManaDeYrys_Agotado")
            {
                Manas[i].sprite = ManaYrys;
            }
            else
            {
                Manas[i].sprite = ManaN;
            }
        }
    }

    private void RivalRestoreManas(int aux, Image[] RivalManas)
    {
        Debug.Log("Rival");
        for (int i = 0; i <= aux; i++)
        {


            if (Manas[i].sprite.name == "ManaDeDana_Agotado")
            {
                RivalManas[i].sprite = ManaDana;
            }
            else if (Manas[i].sprite.name == "ManaDeEtse_Agotado")
            {
                RivalManas[i].sprite = ManaEtse;
            }
            else if (Manas[i].sprite.name == "ManaDeMiknit_Agotado")
            {
                RivalManas[i].sprite = ManaMiknit;
            }
            else if (Manas[i].sprite.name == "ManaDeChronos_Agotado")
            {
                RivalManas[i].sprite = ManaChronos;
            }
            else if (Manas[i].sprite.name == "ManaDeMurgu_Agotado")
            {
                RivalManas[i].sprite = ManaMurgu;
            }
            else if (Manas[i].sprite.name == "ManaDeYrys_Agotado")
            {
                RivalManas[i].sprite = ManaYrys;
            }
            else
            {
                RivalManas[i].sprite = ManaN;
            }
        }
    }

    private void yourSpendManas(string god,int aux2, Image[] Manas)
    {
        aux2--;


        for (int i = aux2; i > yourActualMana-1; i--)
        {
            if (god == "N")
            {
                Manas[i].sprite = ManaN_Spent;
            }
            else if (god == "Dana")
            {
                Manas[i].sprite = ManaDana_Spent;
            }
            else if (god == "Etse")
            {
                Manas[i].sprite = ManaEtse_Spent;
            }
            else if (god == "Miknit")
            {
                Manas[i].sprite = ManaMiknit_Spent;
            }
            else if (god == "Chronos")
            {
                Manas[i].sprite = ManaChronos_Spent;
            }
            else if (god == "Murgu")
            {
                Manas[i].sprite = ManaMurgu_Spent;
            }
            else if (god == "Yrys")
            {
                Manas[i].sprite = ManaYrys_Spent;
            }
        }
       
    }

    private void rivalSpendManas(string god, int aux2,  Image[] RivalManas)
    {
        aux2--;
       

        for (int i = aux2; i > rivalActualMana; i--)
        {
            if (god == "N")
            {
                RivalManas[i].sprite = ManaN_Spent;
            }
            else if (god == "Dana")
            {
                RivalManas[i].sprite = ManaDana_Spent;
            }
            else if (god == "Etse")
            {
                RivalManas[i].sprite = ManaEtse_Spent;
            }
            else if (god == "Miknit")
            {
                RivalManas[i].sprite = ManaMiknit_Spent;
            }
            else if (god == "Chronos")
            {
                RivalManas[i].sprite = ManaChronos_Spent;
            }
            else if (god == "Murgu")
            {
                RivalManas[i].sprite = ManaMurgu_Spent;
            }
            else if (god == "Yrys")
            {
                RivalManas[i].sprite = ManaYrys_Spent;
            }
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

    public void battle(Card atacker, Card defender)
    {
        

        battlePanel.SetActive(true);
        Card attackerCard = atacker;
        Card defenderCard = defender;

        DisplayCard atackerDisplay = atackerGO.GetComponent<DisplayCard>();
        DisplayCard defenderDisplay = defenderGO.GetComponent<DisplayCard>();

        atackerDisplay.updateDisplay(attackerCard.cardId);
        defenderDisplay.updateDisplay(defenderDisplay.cardId);


    }


}
   


        
    

