using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ni : MonoBehaviour
{
    public Shrewberry shrewberry;

    // Update is called once per frame
    void Update()
    {
        if(shrewberry.isPicked == true)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
