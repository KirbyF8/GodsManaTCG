using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurns;
    public int rivalTurns;

    public int maxManaYou = 0;
    public int yourActualMana = 0;
    public int maxManaRival = 0;
    public int RivalActualMana;

    private string normalMana = "N";

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



    private void Start()
    {
        TurnSelect();
        // !Draw 6 cards
        StartTurn();
    }

    private void StartTurn()
    {
        if (isYourTurn)
        {
            if (yourTurns == 0 && rivalTurns == 0)
            {

                maxManaYou++;
                yourActualMana = maxManaYou;
                ManaChanges("N", 0, isYourTurn);
                yourTurns++;
            }
            else
            {

                maxManaYou++;
                yourActualMana = maxManaYou;
                //! draw card
                yourTurns++;
            }
        }

        if (!isYourTurn)
        {
            if (rivalTurns == 0 && yourTurns == 0)
            {
                isYourTurn = false;
                maxManaYou++;
                yourActualMana = maxManaYou;
                rivalTurns++;
            }
            else
            {
                isYourTurn = false;
                maxManaYou++;
                yourActualMana = maxManaYou;
                //! draw card
                rivalTurns++;
            }
        }

    }

    private void TurnSelect()
    {
        int coin = Random.Range(0, 2);
        if (coin == 0)
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

        }
        else if (!isYourTurn)
        {
            isYourTurn = true;
        }

        StartTurn();
    }


    // !0 Add new mana
    //? 1 Restore Mana
    //! 2 Spend Mana
    public void ManaChanges(string god, int operation, bool turn)
    {
        int aux;
        int aux2;
        Image[] auxImg;
        if (turn)
        {
            aux = maxManaYou;
            aux2 = yourActualMana;
            
        }
        else
        {
            aux = maxManaYou;
            aux2 = yourActualMana;
            
        }
        

        if (operation == 0)
        {
            if (god == "N")
            {
                Manas[aux--].sprite = ManaN;
            }
            else if (god == "Dana")
            {
                Manas[aux--].sprite = ManaDana;
            }
            else if (god == "Etse")
            {
                Manas[aux--].sprite = ManaEtse;
            }
            else if (god == "Miknit")
            {
                Manas[aux--].sprite = ManaMiknit;
            }
            else if (god == "Chronos")
            {
                Manas[aux--].sprite = ManaChronos;
            }
            else if (god == "Murgu")
            {
                Manas[aux--].sprite = ManaMurgu;
            }
            else if (god == "Yrys")
            {
                Manas[aux--].sprite = ManaYrys;
            }
        }

        if (operation == 1)
        {
            for (int i = 0; i < aux; i++)
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

        if (operation == 2)
        {
           if (turn)
            {
                yourSpendManas(god, aux2,ref Manas);
            }else if (!turn)
            {
                rivalSpendManas(god, aux2,ref RivalManas);
            }
          }
}
    private void yourSpendManas(string god,int aux2,ref Image[] Manas)
    {
        if (god == "N")
        {
            Manas[aux2--].sprite = ManaN_Spent;
        }
        else if (god == "Dana")
        {
            Manas[aux2--].sprite = ManaDana_Spent;
        }
        else if (god == "Etse")
        {
            Manas[aux2--].sprite = ManaEtse_Spent;
        }
        else if (god == "Miknit")
        {
            Manas[aux2--].sprite = ManaMiknit_Spent;
        }
        else if (god == "Chronos")
        {
            Manas[aux2--].sprite = ManaChronos_Spent;
        }
        else if (god == "Murgu")
        {
            Manas[aux2--].sprite = ManaMurgu_Spent;
        }
        else if (god == "Yrys")
        {
            Manas[aux2--].sprite = ManaYrys_Spent;
        }
    }

    private void rivalSpendManas(string god, int aux2, ref Image[] RivalManas)
    {
        if (god == "N")
        {
            RivalManas[aux2--].sprite = ManaN_Spent;
        }
        else if (god == "Dana")
        {
            RivalManas[aux2--].sprite = ManaDana_Spent;
        }
        else if (god == "Etse")
        {
            RivalManas[aux2--].sprite = ManaEtse_Spent;
        }
        else if (god == "Miknit")
        {
            RivalManas[aux2--].sprite = ManaMiknit_Spent;
        }
        else if (god == "Chronos")
        {
            RivalManas[aux2--].sprite = ManaChronos_Spent;
        }
        else if (god == "Murgu")
        {
            RivalManas[aux2--].sprite = ManaMurgu_Spent;
        }
        else if (god == "Yrys")
        {
            RivalManas[aux2--].sprite = ManaYrys_Spent;
        }
    }


}
   


        
    

