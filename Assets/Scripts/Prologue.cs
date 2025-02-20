using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Prologue : MonoBehaviour
{
    [SerializeField] MainMenu menu;

    [SerializeField] TextMeshProUGUI textBox;
    [SerializeField] Image imageLeft;
    [SerializeField] Image imageRight;
    [SerializeField] Image background;

    [SerializeField] Sprite[] godsSprites;
    [SerializeField] Sprite mainCharacter;
    [SerializeField] Sprite truck;
    [SerializeField] Sprite[] backgrounds;
   

    [SerializeField] private string[] dialogues;
    private int actualText = 0;
    private bool runningText;

    [SerializeField] GameObject textBoxBackground;

    private bool runningAnimation = false;
    void Start()
    {
        actualText = 0;
        background.sprite = backgrounds[0];

        StartCoroutine("UpdateText");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && runningAnimation == false)
        {
            if (runningText)
            {
                
                StopCoroutine("UpdateText");
                FullText();
                runningText = false;
            }
            else
            {
                actualText++;
                StartCoroutine("UpdateText");
            }
            
        }

    }

    private IEnumerator UpdateText()
    {

        UpdateImages();
        runningText = true;
        textBox.text = "";
        yield return new WaitForSeconds(0.5f);
        string text = dialogues[actualText];
       
        foreach (char c in text)
        {
         
            textBox.text += c;
            yield return new WaitForSeconds(0.05f);
            
        }
        runningText = false;
       
      
       
        
    }

    private void FullText()
    {
        textBox.text = dialogues[actualText];
    }
   
    private void UpdateImages()
    {
        if (actualText == 0)
        {
            background.sprite = backgrounds[0];
            imageLeft.sprite = godsSprites[0]; 
            imageRight.sprite = godsSprites[3];
            imageRight.color = Color.gray;
        }
        else if (actualText == 1)
        {
            imageRight.sprite = godsSprites[4];
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        }
        else if (actualText == 2)
        {
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[2];
            imageRight.color = Color.gray;
        }
        else if (actualText == 3)
        {
            imageRight.sprite = godsSprites[1];
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        }
        else if (actualText == 4)
        {
            imageLeft.sprite = godsSprites[5];
            imageLeft.color = Color.white;
            imageRight.color = Color.gray;
        }
        else if (actualText == 5)
        {
            imageRight.sprite = godsSprites[0];
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        }
        else if (actualText == 6)
        {
            imageLeft.sprite = godsSprites[3];
            imageLeft.color = Color.white;
            imageRight.color = Color.gray;
        }
        else if (actualText == 7)
        {
            imageRight.sprite = godsSprites[0];
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        }
        else if (actualText == 8)
        {
            imageLeft.color = Color.white;
            imageRight.color = Color.gray;
        }
        else if (actualText == 9)
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
            imageRight.sprite = godsSprites[5];
        }
        else if (actualText == 10)
        {
            imageLeft.color = Color.white;
            imageRight.color = Color.gray;
        }
        else if (actualText == 11)
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
            imageRight.sprite = godsSprites[1];
        }
        else if (actualText == 12)
        {
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[4];
            imageRight.color = Color.gray;
        }
        else if (actualText == 13)
        {
            imageLeft.sprite = godsSprites[3];
        }
        else if (actualText == 14)
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
            imageRight.sprite = godsSprites[2];
        }
        else if (actualText == 15)
        {
            imageLeft.color = Color.white;
            imageRight.color = Color.gray;
        }
        else if (actualText == 16)
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
            imageRight.sprite = godsSprites[0];
        }
        else if (actualText == 17)
        {
            imageLeft.color = Color.white;
            imageRight.color = Color.gray;
        }
        else if (actualText == 18)
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
            imageRight.sprite = godsSprites[4];
        }
        else if (actualText == 19)
        {
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[5];
            imageRight.color = Color.gray;
        }
        else if (actualText == 20)
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
        }
        else if (actualText == 21)
        {
            imageLeft.gameObject.SetActive(false);
            imageRight.gameObject.SetActive(false);
            background.sprite = backgrounds[1];
        }
        else if (actualText == 22)
        {
            imageLeft.gameObject.SetActive(true);
            imageRight.gameObject.SetActive(true);
            imageLeft.sprite = godsSprites[2];
            imageLeft.color = Color.white;
            imageRight.sprite = godsSprites[4];
            imageRight.color = Color.gray;
        }
        else if (actualText == 23)
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
        }
        else if (actualText ==24)
        {
            imageRight.color = Color.gray;
            imageLeft.sprite = godsSprites[0];
            imageLeft.color = Color.white;
        }
        else if (actualText == 25)
        {
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        }
        else if (actualText == 26)
        {
            imageLeft.sprite = godsSprites[1];
            imageLeft.color = Color.white;
            imageRight.color = Color.gray;
        }
        else if (actualText == 27) 
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
            imageRight.sprite = godsSprites[5];
        }
        else if (actualText == 28)
        {
            imageRight.color = Color.gray;
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[2];
        }
        else if (actualText == 29)
        {
            imageRight.sprite = godsSprites[1];
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
        } 
        else if (actualText == 30)
        {
            imageRight.color = Color.gray;
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[0];
        }
        else if (actualText == 31)
        {
            imageLeft.gameObject.SetActive(false);
            imageRight.gameObject.SetActive(false);
            background.sprite = backgrounds[2];
        }
        else if (actualText == 32)
        {
            imageRight.gameObject.SetActive(true);
            imageRight.color = Color.white;
            imageRight.sprite = mainCharacter;
        }
        else if (actualText == 34)
        {
            imageLeft.gameObject.transform.localScale = new Vector3 (-1,1,1);
            imageRight.color = Color.gray;
            imageLeft.gameObject.SetActive(true);
            imageLeft.sprite = truck;
        } 
        else if (actualText == 35)
        {
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        }
        else if (actualText == 36)
        {
            imageLeft.color = Color.white;
            textBoxBackground.SetActive(false);
            runningAnimation = true;
            StartCoroutine(AnimationAccident());
        } 
        else if (actualText == 37)
        {
            background.sprite = backgrounds[1];
            imageLeft.gameObject.SetActive(false);
        }
        else if (actualText == 38)
        {
            imageLeft.gameObject.SetActive(false);
            background.sprite = backgrounds[1];
        }
        else if (actualText == 39)
        {
            imageRight.color = Color.gray;
            imageLeft.gameObject.SetActive(true) ;
            imageLeft.sprite = godsSprites[1];
            imageLeft.color = Color.white;
        }
        else if (actualText == 40)
        {
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        }
        else if (actualText == 41)
        {
            imageRight.color = Color.gray;
            imageLeft.color = Color.white;
        }
        else if (actualText == 42)
        {
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        }
        else if (actualText == 44)
        {
            imageRight.color = Color.gray;
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[0];
        }
        else if (actualText == 45)
        {
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        } 
        else if (actualText == 46)
        {
            imageRight.color = Color.gray;
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[5];
        }
        else if (actualText == 47)
        {
            imageRight.color = Color.gray;
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[0];
        }
        else if (actualText == 48)
        {
            imageRight.color = Color.white;
            imageLeft.color = Color.gray;
        }
        else if (actualText == 49)
        {
            imageRight.color = Color.gray;
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[3];
        } 
        else if (actualText == 50)
        {
            imageLeft.sprite = godsSprites[5];
        }
        else if (actualText == 51)
        {
            imageLeft.sprite = godsSprites[0];
        }
        else if (actualText == 52)
        {
            imageLeft.sprite = godsSprites[1];
        }
        else if (actualText == 53)
        {
            imageLeft.sprite = godsSprites[2];
        } 
        else if (actualText == 54)
        {
            imageLeft.sprite = godsSprites[4];
        } 
        else if (actualText == 55)
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
        }
        else if (actualText == 56)
        {
            imageLeft.color = Color.white;
            imageLeft.sprite = godsSprites[0];
            imageRight.color = Color.gray;
        }
        else if (actualText == 57)
        {
            imageLeft.color = Color.gray;
            imageRight.color = Color.white;
        } else if (actualText == 58)
        {
            menu.GoToLvl1();
        }
    }

    private IEnumerator AnimationAccident()
    {
        yield return new WaitForSeconds(0.5f);
        
        imageLeft.gameObject.transform.DOShakePosition(5f, 125, 100, 90, false, false);
        imageRight.gameObject.transform.DOShakePosition(5f, 125, 100, 90, false, false).OnComplete(ContinueText);
    }

    private void ContinueText()
    {
        textBoxBackground.SetActive(true);
        runningAnimation = false;
        actualText++;
        UpdateText();

    }
}
