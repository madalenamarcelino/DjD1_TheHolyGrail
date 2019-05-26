using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrewberry : MonoBehaviour
{
    public bool isPicked = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPicked = true;
            Object.Destroy(this.gameObject);
        }
    }
}
