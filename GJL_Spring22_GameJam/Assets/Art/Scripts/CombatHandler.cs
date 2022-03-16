using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public static CombatHandler instance;

    public bool AttackIsPressed = true;

    public Animator animator;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TopDownCharacterController.instance.isFacingRight)
            {
                animator.SetTrigger("AttackRight");
            }

            else
            {
                animator.SetTrigger("AttackLeft");

            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackIsPressed = true;
        }

        else

        {
            AttackIsPressed = false;
        }
           
    }

}

