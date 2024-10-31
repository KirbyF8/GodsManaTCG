using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    private int coins;
    [SerializeField] private Sprite[] boosterPacksSprites;
    [SerializeField] private int[] prices;
    [SerializeField] private string[] boosterPacksNames;

    [SerializeField] private Image boosterImage1;
    [SerializeField] private Image boosterImage2;
    [SerializeField] private Image boosterImage3;

    private int boosterHint = 1;

    [SerializeField] private TextMeshProUGUI price1;
    [SerializeField] private TextMeshProUGUI price2;

    [SerializeField] GameObject panelPack;
    [SerializeField] private Image buyedBoosterImage;
    [SerializeField] GameObject buyedBooster;

   [SerializeField] private DisplayCard[] cardsInBooster;

    private string buyedBoosterPack;
 
    void Start()
    {
        SetImages(boosterHint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadCoins()
    {

    }
    //? 0 <-
    //? 1 ->
    public void ChangeBoosterPack(int direct)
    {
    
        if (direct == 1)
        {
            boosterHint += 1;
            if (boosterHint > boosterPacksNames.Length - 1)
            {
                boosterHint = 0;
            }
            
            SetImages(boosterHint);
            return;
        }

        if (direct == 0)
        {
            if (boosterHint >= 1)
            {
                boosterHint -= 1;
                SetImages(boosterHint);
                return;
            }
            else
            {
                boosterHint = boosterPacksNames.Length-1;
                SetImages(boosterHint);
                return;
            }
        }
    }

    private void SetImages(int aux)
    {
       
        if (aux == 0)
        {
            boosterImage1.sprite = boosterPacksSprites[boosterPacksNames.Length -1];
            boosterImage2.sprite = boosterPacksSprites[aux];
            price1.text = prices[aux]+ " GOLD!!!";
            price2.text = prices[aux] + " GOLD!!!";
            boosterImage3.sprite = boosterPacksSprites[aux+1];
            return;
        }
        

        if (aux == boosterPacksNames.Length - 1)
        {
            boosterImage1.sprite = boosterPacksSprites[aux-1];
            boosterImage2.sprite = boosterPacksSprites[aux];
            price1.text = prices[aux] + " GOLD!!!";
            price2.text = prices[aux] + " GOLD!!!";
            boosterImage3.sprite = boosterPacksSprites[0];
            return;
        }
        
        boosterImage1.sprite = boosterPacksSprites[aux-1];
        
        boosterImage2.sprite = boosterPacksSprites[aux];
        price1.text = prices[aux] + " GOLD!!!";
        price2.text = prices[aux] + " GOLD!!!";
        boosterImage3.sprite = boosterPacksSprites[aux + 1];

        
    }


    private int first;
    private int second;
    public void BuyPack()
    {
        panelPack.SetActive(true);
        buyedBoosterImage.sprite = boosterPacksSprites[boosterHint];
        buyedBoosterPack = boosterPacksNames[boosterHint];
        
        
      if (buyedBoosterPack == "Mundo Antiguo")
        {
            first = 1;
            second = 46;
        }
      else if (buyedBoosterPack == "Revolucion Steampunk")
        {
            first = 46;
            second = 92;
        }
      else if (buyedBoosterPack == "Miknit's Mana War Legacy")
        {
            first = 92;
            second = 114;
        }
      else if (buyedBoosterPack == "Colaboraciones Radiantes")
        {
            first = 114;
            second = 118;
        }
      else if (buyedBoosterPack == "Magia para novatos y no tan novatos")
        {
            first = 118;
            second = 137;
        }

       

    }

    public void OpenPack()
    {
       

        for (int i = 0; i < cardsInBooster.Length; i++) 
        {
            cardsInBooster[i].displayId = Random.Range(first, second);
            cardsInBooster[i].WhereIAm(3);
            cardsInBooster[i].updateDisplay(cardsInBooster[i].displayId);
        }
        buyedBooster.SetActive(false);
    }
}
