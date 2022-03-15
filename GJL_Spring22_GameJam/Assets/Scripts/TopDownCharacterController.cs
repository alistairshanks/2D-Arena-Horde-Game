using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private Vector3 moveDir;
    public Animator animator;

    public float MOVE_SPEED = 20f;

    private void Awake()
    {
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
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = moveDir * MOVE_SPEED;
    }
}
