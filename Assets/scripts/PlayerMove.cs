using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public PlayerController reference;      // a reference to the character controller script

    public float mVelocity = 50f;           // movement velocity
    float moveH = 0f;                       // default is 0

    bool jump = false;


    // Update is called once per frame
    void Update()
    {
        //get user input from 0 to 1 or -1
        moveH = Input.GetAxis("Horizontal") * mVelocity;
        //restrict jump for only when space is pressed
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        //actually move player
        reference.Go(moveH * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
