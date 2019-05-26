using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextAnim : StateMachineBehaviour
{
    public Animator anim;

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        anim.SetTrigger("StayUp");
    }
}
