using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public bool isOnTrigger;
    public bool started = false;
    public bool isActive = true;

    public AudioClip audioClip;
    public SpriteRenderer spriterenderer;

    public TextMeshProUGUI textDisplay;
    public float textSpeed;
    public string[] sentences;
    private int index;
    public GameObject continueButton;
    

    private void Awake()
    {
        isOnTrigger = false;
        continueButton.SetActive(false);
        spriterenderer.enabled = false;
    }
    private void Update()
    {
        if (textDisplay.text == sentences[index])
            continueButton.SetActive(true);
        StartConvo();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive == true)
        {
            isOnTrigger = true;
            spriterenderer.enabled = true;
            
        }


        else
        {
            isOnTrigger = false;
            spriterenderer.enabled = false;
        }
            

    }


    void StartConvo()
    {
        if (isOnTrigger == true && Input.GetKeyDown(KeyCode.E) && started == false)
        {
            started = true;
            StartCoroutine(Type());
            isActive = false;
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            
        }
        else
        {
            textDisplay.text = " ";
            continueButton.SetActive(false);
            spriterenderer.enabled = false;
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textSpeed);

        }
    }



}
