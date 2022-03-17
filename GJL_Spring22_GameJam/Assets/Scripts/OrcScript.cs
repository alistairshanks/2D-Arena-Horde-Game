using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcScript : MonoBehaviour
{

    public Transform player;
    private Vector2 movement;

    private Rigidbody2D myRigidbody2d;
    public float moveSpeed = 3f;

    public bool isMovingUp;
    public bool isMovingRight;
    public bool isTakingDamage;

    public Vector3 previousPosition;
    public Vector3 currentPosition;

    private string animationAction;
    private string animationFacing;
    private string animationDirection;

    private string currentState;

    public Animator animator;

    private void Start()
    {
        myRigidbody2d = this.GetComponent<Rigidbody2D>();
        previousPosition = transform.position;
    }
    void Update()
    {
        currentPosition = transform.position;

        Vector3 direction = player.position - transform.position;

      //  float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        


        direction.Normalize();
        movement = direction;

        if (currentPosition.y > previousPosition.y)
        {
            animationFacing = "Up";
        }

        else if (currentPosition.y < previousPosition.y)
        {
            animationFacing = "Down";
        }

        if (currentPosition.x > previousPosition.x)
        {
            animationDirection = "Right";
        }
        
        else if (currentPosition.x < previousPosition.x)
        {
            animationDirection = "Left";
        }

        if (isTakingDamage == true)
        {
            animationAction = "Damage";

            Invoke("Dead", 0.3f);
        }

        else animationAction = "Walk";


        ChangeAnimationState(animationAction + animationFacing + animationDirection);


        previousPosition = transform.position;
    }

    void moveEnemyAi(Vector2 direction)
    {
        myRigidbody2d.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        moveEnemyAi(movement);
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

  
    void Dead()
    {
        Destroy(gameObject);
    }

}
