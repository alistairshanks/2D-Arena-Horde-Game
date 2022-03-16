using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator animator;
    private string currentAnimation;
    private string currentState;

    // Animation States 

    const string PLAYER_IDLE_RIGHT = "IdleFacingRight";
    const string PLAYER_IDLE_LEFT = "IdleFacingLeft";
    const string PLAYER_IDLE_BACKRIGHT = "IdleFacingBackRight";
    const string PLAYER_IDLE_BACKLEFT = "IdleFacingBackLeft";

    const string PLAYER_WALK_RIGHT = "WalkingRight";
    const string PLAYER_WALK_LEFT = "WalkingLeft";
    const string PLAYER_WALK_BACKRIGHT = "WalkingBackRight";
    const string PLAYER_WALK_BACKLEFT = "WalkingBackLeft";

    const string ATTACK_RIGHT = "AttackRight";
    const string ATTACK_LEFT = "AttackLeft";
    const string ATTACK_BACKRIGHT = "AttackRightBack";
    const string ATTACK_BACKLEFT = "AttackLeftBack";

    const string DAMAGE_RIGHT = "DamageRight";
    const string DAMAGE_LEFT = "DamageLeft";
    const string DAMAGE_BACKRIGHT = "DamageBackLeft";
    const string DAMAGE_BACKLEFT = "DamageBackRight";

    const string DEATH = "Death";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself 
        if (currentState == newState) return;

        //play the animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //this determines where the character is looking when standing still

        if (TopDownCharacterController.instance.isStandingStill)
        {
            if (TopDownCharacterController.instance.isFacingUp)

            {
                if (TopDownCharacterController.instance.isFacingRight)
                {
                    ChangeAnimationState(PLAYER_IDLE_BACKRIGHT);

                    
                }



                else
                {
                    ChangeAnimationState(PLAYER_IDLE_BACKLEFT);
                    
                }
            }

            else
            {

                if (TopDownCharacterController.instance.isFacingRight)
                {

                    ChangeAnimationState(PLAYER_IDLE_RIGHT);
                    
                }

                else
                {
                    ChangeAnimationState(PLAYER_IDLE_LEFT);
                    
                }


            }
        }

        //this determines what animation to play when character is moving 

        else
        {
            if (TopDownCharacterController.instance.isFacingUp)

            {
                if (TopDownCharacterController.instance.isFacingRight)
                {
                    ChangeAnimationState(PLAYER_WALK_BACKRIGHT);

                }

                else
                {
                    ChangeAnimationState(PLAYER_WALK_BACKLEFT);
                }
            }

            else
            {
                if (TopDownCharacterController.instance.isFacingRight)
                {
                    ChangeAnimationState(PLAYER_WALK_RIGHT);
                }

                else
                {
                    ChangeAnimationState(PLAYER_WALK_LEFT);
                }
            }


            //this determines which direction to attack 

            if (TopDownCharacterController.instance.AttackIsPressed)
            {

                TopDownCharacterController.instance.AttackIsPressed = false;



                if (!TopDownCharacterController.instance.AttackIsPressed)

                {
                    if (TopDownCharacterController.instance.isFacingUp)

                    {
                        if (TopDownCharacterController.instance.isFacingRight)
                        {
                            ChangeAnimationState(ATTACK_BACKRIGHT);

                        }



                        else
                        {
                            ChangeAnimationState(ATTACK_BACKLEFT);

                        }

                    }

                    else
                    {

                        if (TopDownCharacterController.instance.isFacingRight)
                        {

                            ChangeAnimationState(ATTACK_RIGHT);
                        }

                        else
                        {
                            ChangeAnimationState(ATTACK_LEFT);

                        }
                    }
                }

            }
        }
            



               
        
        





    }










}







