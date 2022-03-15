using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;
    private string currentAnimation;
    private string currentState;

    // Animation States 

    const string PLAYER_IDLE_RIGHT = "IdleFacingRight";
    const string PLAYER_IDLE_LEFT = "IdleFacingLeft";
    const string PLAYER_IDLE_BACKRIGHT = "IdleFacingBackRght";
    const string PLAYER_IDLE_BACKLEFT = "IdleFacingBackLeft";

    const string PLAYER_WALK_RIGHT = "WalkingRight";
    const string PLAYER_WALK_LEFT = "WalkingLeft";
    const string PLAYER_WALK_BACKRIGHT = "WalkingBackRight";
    const string PLAYER_WALK_BACKLEFT = "WalkingLeft";

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
        if (TopDownCharacterController.instance.isFacingRight) 

        {
            

        }






    }










}







