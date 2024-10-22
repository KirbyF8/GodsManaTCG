using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int cardId;
    public string cardName;
    public int cardCost;
    public int cardAttack;
    public int cardDefense;
    public int cardHealth;
    public string cardDescription;
    public string cardType;


    public string cardClass;
    // Extra info
    public int cardRarity;

    public TMP_Text nameText;
    public TMP_Text manaCostText;
    public TMP_Text attackText;
    public TMP_Text defenseText;
    public TMP_Text healthText;
    public TMP_Text descriptionText;
    public TMP_Text cardText;

    
    public Image cardImg;

    public Image fondoCarta;
    public Image fondoMana;
    public Image fondoName;
    public Image fondoTxt;

    public bool isFlipped;

    [SerializeField] private GameObject cardBack;

    [SerializeField] private Sprite Fondo_Dana;
    [SerializeField] private Sprite Fondo_Murgu;
    [SerializeField] private Sprite Fondo_Etse;
    [SerializeField] private Sprite Fondo_Yrys;
    [SerializeField] private Sprite Fondo_Chronos;
    [SerializeField] private Sprite Fondo_Miknit;

    [SerializeField] private Sprite Mana_Dana;
    [SerializeField] private Sprite Mana_Murgu;
    [SerializeField] private Sprite Mana_Etse;
    [SerializeField] private Sprite Mana_Yrys;
    [SerializeField] private Sprite Mana_Chronos;
    [SerializeField] private Sprite Mana_Miknit;

    [SerializeField] private Sprite Name_Dana;
    [SerializeField] private Sprite Name_Murgu;
    [SerializeField] private Sprite Name_Etse;
    [SerializeField] private Sprite Name_Yrys;
    [SerializeField] private Sprite Name_Chronos;
    [SerializeField] private Sprite Name_Miknit;

    [SerializeField] private Sprite Txt_Dana;
    [SerializeField] private Sprite Txt_Murgu;
    [SerializeField] private Sprite Txt_Etse;
    [SerializeField] private Sprite Txt_Yrys;
    [SerializeField] private Sprite Txt_Chronos;
    [SerializeField] private Sprite Txt_Miknit;

    private GameAssets gameAssets;

    private Sprite[] cardImgs;


    void Start()
    {

        isFlipped = true;

        gameAssets = FindAnyObjectByType<GameAssets>();

        cardImgs = gameAssets.cardImgs;

        displayCard[0] = CardDatabase.cardList[displayId];
        SetCard();
        

        
        
    }

    


    void SetCard()
    {
        cardId = displayCard[0].cardId;
        cardName = displayCard[0].cardName;
        cardCost = displayCard[0].cardCost;
        cardAttack = displayCard[0].cardAttack;
        cardDefense = displayCard[0].cardDefense;
        cardHealth = displayCard[0].cardHealth;
        cardDescription = displayCard[0].cardDescription;
        cardType = displayCard[0].cardType;
        cardClass = displayCard[0].cardClass;

        nameText.text = cardName;
        manaCostText.text = "" + cardCost;
        attackText.text = "" + cardAttack;
        defenseText.text = "" + cardDefense;
        healthText.text = "" + cardHealth;
        descriptionText.text = cardDescription;
        cardText.text = "" + cardClass;

        /*
        if (cardImgs.Length >= cardId - 1)
        {
            cardImg.sprite = cardImgs[cardId - 1];

        }
        else
        {
            Debug.Log(cardImgs.Length);
        }*/
        


        if (cardType == "Miknit")
        {
            fondoCarta.sprite = Fondo_Miknit;
            fondoMana.sprite = Mana_Miknit;
            fondoName.sprite = Name_Miknit;
            fondoTxt.sprite = Txt_Miknit;
        }
        else if (cardType == "Chronos")
        {

            fondoCarta.sprite = Fondo_Chronos;
            fondoMana.sprite = Mana_Chronos;
            fondoName.sprite = Name_Chronos;
            fondoTxt.sprite = Txt_Chronos;
        }
        else if (cardType == "Yrys")
        {
            fondoCarta.sprite = Fondo_Yrys;
            fondoMana.sprite = Mana_Yrys;
            fondoName.sprite = Name_Yrys;
            fondoTxt.sprite = Txt_Yrys;
        }
        else if (cardType == "Murgu")
        {
            fondoCarta.sprite = Fondo_Murgu;
            fondoMana.sprite = Mana_Murgu;
            fondoName.sprite = Name_Murgu;
            fondoTxt.sprite = Txt_Murgu;
        }
        else if (cardType == "Dana")
        {
            fondoCarta.sprite = Fondo_Dana;
            fondoMana.sprite = Mana_Dana;
            fondoName.sprite = Name_Dana;
            fondoTxt.sprite = Txt_Dana;
        }
        else if (cardType == "Etse")
        {
            fondoCarta.sprite = Fondo_Etse;
            fondoMana.sprite = Mana_Etse;
            fondoName.sprite = Name_Etse;
            fondoTxt.sprite = Txt_Etse;
        }
        else
        {
            return;
        };

    }

    public void faceDown_faceUp()
    {
        if (isFlipped)
        {
            cardBack.SetActive(false);
        }
        else
        {
            cardBack.SetActive(true);
        }
    }

    public void updateDisplay(int Id)
    {
        displayId = Id;
        SetCard();
    }
}
