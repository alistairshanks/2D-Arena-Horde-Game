using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
  
    private string animationAction;
    private string animationFacing;
    private string animationDirection;


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
            animationAction = "Idle";
        }
        if(TopDownCharacterController.instance.isStandingStill == false && TopDownCharacterController.instance.isAttacking == false)
        {
            animationAction = "Walk";
        }
        if(TopDownCharacterController.instance.isAttacking == true)
        {
            animationAction = "Attack";
        }





        if (TopDownCharacterController.instance.isFacingUp == true)
        {
            animationFacing = "FacingUp";
        }
        else
        {
            animationFacing = "FacingDown";
        }


        if(TopDownCharacterController.instance.isFacingRight == true)
        {
            animationDirection = "Right";
        }
        else
        {
            animationDirection = "Left";
        }

        ChangeAnimationState(animationAction + animationFacing + animationDirection);



    }

}
