using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool isActive = true;
    public bool isOnTrigger;

    public SpriteRenderer spriterenderer;

    public Dialogue1 dialogue;
    public GameObject continueButton;

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

    public void TriggerDialogue()
    {
        if (isOnTrigger == true && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            spriterenderer.enabled = false;
        }
    }
}
