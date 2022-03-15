using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{

    public static TopDownCharacterController instance;


    private Rigidbody2D myRigidbody2D;
    private Vector3 moveDir;


    public Animator animator;
    public bool isFacingRight = true;
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
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;

            
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
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = moveDir * MOVE_SPEED;
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
