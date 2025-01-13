using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{

    //! --- Pasar a Array- --
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


    public void AddManas(string god, int aux)
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

    public void RestoreManas(int aux)
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

    public void SpendManas(string god, int aux2, int ActualMana)
    {
        aux2--;


        for (int i = aux2; i > ActualMana - 1; i--)
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
}
