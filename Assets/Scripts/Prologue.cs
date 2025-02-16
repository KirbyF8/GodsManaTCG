using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class Prologue : MonoBehaviour
{
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

    void Start()
    {
        actualText = 0;
        background.sprite = backgrounds[0];

        StartCoroutine("UpdateText");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
            yield return new WaitForSeconds(0.1f);
            
        }
        
       
      
       
        
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
            imageLeft.sprite = truck; //? CAMBIAR
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
            imageRight.sprite = truck; //? Cambiar
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
            imageRight.sprite = truck; //? Cambiar
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
            imageRight.sprite = truck; //? Cambiar
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
        }


    }
}
