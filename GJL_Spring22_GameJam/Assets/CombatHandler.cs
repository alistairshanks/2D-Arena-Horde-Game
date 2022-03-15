using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{
    // Start is called before the first frame update

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

    }
}
