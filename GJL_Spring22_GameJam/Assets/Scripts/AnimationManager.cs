using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
  
    private string action;
    private string facing;
    private string direction;


    // example string for "character" + "action" + "facing" + "direction" would be "player" + "walk" + "front" + "left"


    public Animator animator;
    private string currentAnimation;
    private string currentState;



    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself 
        if (currentState == newState) return;

        //play the animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }


    private void FixedUpdate()
    {

        if (TopDownCharacterController.instance.isStandingStill == true && TopDownCharacterController.instance.isAttacking == false)
        {
            action = "Idle";
        }
        if(TopDownCharacterController.instance.isStandingStill == false && TopDownCharacterController.instance.isAttacking == false)
        {
            action = "Walk";
        }
        if(TopDownCharacterController.instance.isAttacking == true)
        {
            action = "Attack";
        }





        if (TopDownCharacterController.instance.isFacingUp == true)
        {
            facing = "FacingUp";
        }
        else
        {
            facing = "FacingDown";
        }


        if(TopDownCharacterController.instance.isFacingRight == true)
        {
            direction = "Right";
        }
        else
        {
            direction = "Left";
        }

        ChangeAnimationState(action + facing + direction);



    }

}
