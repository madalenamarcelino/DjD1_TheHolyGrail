using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPlatfrm : MonoBehaviour
{
    Animator anim;
    public bool isActive;

    private void OnTriggerEnter(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E) && isActive == true)
        {

        }
    }
}
