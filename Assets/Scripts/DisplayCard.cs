using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.PointerEventData;

public class DisplayCard : MonoBehaviour, IPointerDownHandler//
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
    [SerializeField] private Sprite Fondo_N;

    [SerializeField] private Sprite Mana_Dana;
    [SerializeField] private Sprite Mana_Murgu;
    [SerializeField] private Sprite Mana_Etse;
    [SerializeField] private Sprite Mana_Yrys;
    [SerializeField] private Sprite Mana_Chronos;
    [SerializeField] private Sprite Mana_Miknit;
    [SerializeField] private Sprite Mana_N;

    [SerializeField] private Sprite Name_Dana;
    [SerializeField] private Sprite Name_Murgu;
    [SerializeField] private Sprite Name_Etse;
    [SerializeField] private Sprite Name_Yrys;
    [SerializeField] private Sprite Name_Chronos;
    [SerializeField] private Sprite Name_Miknit;
    [SerializeField] private Sprite Name_N;

    [SerializeField] private Sprite Txt_Dana;
    [SerializeField] private Sprite Txt_Murgu;
    [SerializeField] private Sprite Txt_Etse;
    [SerializeField] private Sprite Txt_Yrys;
    [SerializeField] private Sprite Txt_Chronos;
    [SerializeField] private Sprite Txt_Miknit;
    [SerializeField] private Sprite Txt_N;

    // [SerializeField] private GameObject healthPlace;
    [SerializeField] private GameObject attackAndDefensePlace;
    [SerializeField] DeckPersistance deckPersistance;

    [SerializeField] private Material materialSR;
    [SerializeField] private Material materialUR;

    private GameAssets gameAssets;

    [SerializeField] private Sprite[] cardImgs;

    private PlayerDeck playerDeck;

    private Card thisCard;

    [SerializeField] Selectable selectable;

    [SerializeField] GameObject selectedOutline;
    [SerializeField] GameObject selectedCheck;
    private ShopUI shopUI;
    private CardEffects cardEffects;
    private TurnManager turnManager;

    private int whereIAm;

    private int cardHpLost;
    private int cardModifiedAtk;
    private int cardModifiedDef;


    void Start()
    {

        isFlipped = true;

        gameAssets = FindAnyObjectByType<GameAssets>();

       

       



        try
        {
            turnManager = FindAnyObjectByType<TurnManager>();
            shopUI = FindAnyObjectByType<ShopUI>();
            cardEffects = FindAnyObjectByType<CardEffects>();
        }
        catch (Exception e)
        {

           
            shopUI = null;
            cardEffects = null;
            turnManager = null;
            Debug.LogException(e);
        }


        try
        {
            if (whereIAm == 5)
            {
                playerDeck = turnManager.returnRivalDeck();
            }
            else if (whereIAm == 1)
            {
                playerDeck = turnManager.returnPlayerDeck();
            }
        }
        catch (Exception ex)
        {
            playerDeck = null;
            Debug.LogException(ex);
        }

        cardImgs = gameAssets.cardImgs;

        cardImgs = Resources.LoadAll<Sprite>("Images");

        cardImgs = cardImgs
    .Where(sprite => int.TryParse(sprite.name, out _)) 
    .OrderBy(sprite => int.Parse(sprite.name))         
    .ToArray();

        displayCard[0] = CardDatabase.cardList[displayId];
        SetCard();
        
        thisCard = displayCard[0];
        
        
    }

 


    void SetCard()
    {
        cardId = displayCard[0].cardId;
        cardName = displayCard[0].cardName;
        cardCost = displayCard[0].cardCost;
        cardAttack = displayCard[0].cardAttack;
        cardDefense = displayCard[0].cardDefense;
        cardHealth = displayCard[0].cardHealth;
        if (cardHpLost != 0)
        {
            cardHealth = displayCard[0].cardHealth-cardHpLost;
        }
        
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
        thisCard = displayCard[0];



        if (whereIAm == 3)
        {
            FoilCard();
        }

        if (cardRarity == 2)
        {
            cardImg.material = materialUR;
        }else if (cardRarity == 1)
        {
            cardImg.material = materialSR;
        }
        else
        {
            cardImg.material = null;
        }


        
        if (cardImgs.Length >= cardId - 1)
        {
            try
            {
                cardImg.sprite = cardImgs[cardId - 1];
            }
            catch (Exception e)
            {
                //Debug.LogException(e);
                cardImg.sprite = null;
            }

        }
     

        

        if (cardClass == "Trampa" || cardClass == "Mágica" || cardClass == "Equipo" || cardClass == "Dominio")
        {

            attackAndDefensePlace.SetActive(false);
            
        }
        else
        {
            attackAndDefensePlace.SetActive(true);
        }


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
            fondoCarta.sprite = Fondo_N;
            fondoMana.sprite = Mana_N;
            fondoName.sprite = Name_N;
            fondoTxt.sprite = Txt_N;

            return;
        };

    }

    public void faceDown()
    {
        
       cardBack.SetActive(true);
        
    }

    public void faceUp()
    {
        cardBack.SetActive(false);
    }

    public void updateDisplay(int Id)
    {
        displayId = Id;
        displayCard[0] = CardDatabase.cardList[displayId];
        SetCard();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (InputButton.Left == eventData.button)
        {
            if (whereIAm == 0)
            {

                return;
            }
            else if (whereIAm == 1)
            {
                playerDeck.canPlayCard(thisCard);
                Destruction();
                return;
            }
            else if (whereIAm == 3)
            {
                Next();
                return;
            }
            else if (whereIAm == 4)
            {
                SelectCard();
                return;
            }
            else if (whereIAm == 5 || whereIAm == 6 || whereIAm == 7)
            {
               return;
            }

           



            

        }

        if (InputButton.Right == eventData.button)
        {
            
            if (whereIAm == 1 || whereIAm == 2 || whereIAm == 6 || whereIAm == 9)
            {
                turnManager.ExamineCard(thisCard);
            }
        }

        if (InputButton.Middle == eventData.button)
        {
            return;
        }



    }

    public void Destruction()
    {
        if (playerDeck.ConfirmDestruction())
        {
            Destroy(gameObject, 0.1f);
        }
        
    }

    private void Next()
    {
        shopUI.cartaGirada();
        deckPersistance.AddSaveCard(thisCard);
        cardBack.SetActive(false);
    }

    private bool selected;
    public void SelectCard()
    {
        
        Card auxcard = returnCard();

        if (selected)
        {
            
            
            selectedOutline.SetActive(false);
            selectedCheck.SetActive(false);
            cardEffects.DeSelectCards(auxcard);
            selected = false;
            return;
        }
        selected = true;
        selectedOutline.SetActive(true);
        selectedCheck.SetActive(true);
        cardEffects.SelectCards(auxcard);
        
    }

    //? 0 Deck Creator
    //? 1 Hand
    //? 2 Field
    //? 3 Shoped
    //? 4 Card SelHéctor
    //? 5 Rival Hand
    //? 6 Rival Hand Flipped
    //? 7 Expositor
    //? 8 Rival Field
    //? 9 DoaminZone
    public void WhereIAm(int aux)
    {
        whereIAm = aux;
        
    }
    Card aux;
    public Card returnCard()
    {
        aux = CardDatabase.cardList[cardId];
        return aux;
    }

    //TODO!!
   public void cardHpLosted(int hp)
    {
        cardHpLost += hp;
        UpdateHealth();
        
    }

    public bool IAmAlive()
    {
        if (cardHealth - cardHpLost <= 0) 
        {
            return true;
        }
        
            return false;
        
    }

    public void FoilCard()
    {
         int random = UnityEngine.Random.Range(0, 101);

        if (random >= 99)
        {
            cardRarity = 2;
        } else if (random >= 94)
        {
            cardRarity= 1;
        } else
        {
            cardRarity = 0;
        }

    }

    private void UpdateHealth()
    {
        cardHealth = displayCard[0].cardHealth - cardHpLost;
    }
}
