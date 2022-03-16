using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{

    public static TopDownCharacterController instance;


    public Vector3 moveDir;

    public Rigidbody2D myRigidbody2D;


   

    public bool isFacingUp = false;
    public bool isFacingRight = true;
    public bool isStandingStill = true;
    public bool AttackIsPressed = false;
    public bool isAttacking;


    public float MOVE_SPEED = 20f;

    private void Awake()
    {
        instance = this;
        
        myRigidbody2D = GetComponent<Rigidbody2D>();

    }
    private void Update()

    {
        float moveX = 0f;
        float moveY = 0f;


        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;

            isFacingUp = true;


        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;

            isFacingUp = false;


        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;

            if (isFacingRight)
            {
                Flip();
            }

        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;

            if (!isFacingRight)
            {
                Flip();
            }
        }

        moveDir = new Vector3(moveX, moveY).normalized;

        if (moveDir.x == 0f && moveDir.y == 0f)
        {
            isStandingStill = true;
        }

        else
        {
            isStandingStill = false;
        }


        if (Input.GetKeyDown("space"))

        {
            AttackIsPressed = true;

            Debug.Log ("space bar was pressed");
        }

      

      

        
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = moveDir * MOVE_SPEED;

        
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;/*

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
   */ }

    void Attack()
    {

    }

    void AttackComplete()
    {
        AttackIsPressed = false;
    }

}
