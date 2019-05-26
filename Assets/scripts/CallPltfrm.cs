using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPltfrm : MonoBehaviour
{
    public bool isOnTrigger;
    public bool isActive = true;
    public Animator anim;
    public SpriteRenderer spriterenderer;

    private void Update()
    {
        PlayPlatform();
    }

    private void Awake()
    {
        isOnTrigger = false;
        spriterenderer.enabled = false;
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

    void PlayPlatform()
    {
        if(isOnTrigger == true && Input.GetKeyDown(KeyCode.E) && isActive == false)
        {
            spriterenderer.enabled = false;
            isActive = false;
            anim.SetTrigger("Change");
        }
    }
}
