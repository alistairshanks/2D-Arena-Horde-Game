using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcScript : MonoBehaviour
{

    public Transform player;
    private Vector2 movement;
    private Vector2 sumOfAiSeperation;

    private Vector2 finalAverageMovement;

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


        // *************** NEW SECTION TO TRY TO STOP AI FROM GROUPING UP TOGETHER **************

        float separateSpeed = moveSpeed / 2f;
        float separateRadius = 0.5f;

       
        float count = 0f;

        // overlapshere to detect others
        var hits = Physics2D.OverlapCircleAll(transform.position, separateRadius);
        foreach (var hit in hits)
        {
            // make sure it is a fellow enemy ** use your enemy script name **
            if (hit.GetComponent<OrcScript>() != null && hit.transform != transform)
            {
                // get the difference so you know which way to go
                Vector2 difference = transform.position - hit.transform.position;

                // weight by distance so being closer means moving more
                difference = difference.normalized / Mathf.Abs(difference.magnitude);

                // add together to get average of the group
                // this allows those at the edges of a group to move out while
                // the enemies in the center of a group to not move much
                sumOfAiSeperation += difference;
                count++;
            }
        }

        if (count > 0)
        {
            // average the direction
            sumOfAiSeperation /= count;

           
        }
        else
        {
            sumOfAiSeperation = Vector2.zero;
        }


        sumOfAiSeperation = sumOfAiSeperation.normalized;

        /*

                  // set the speed of movement
                  sumOfAiSeperation = sumOfAiSeperation.normalized * separateSpeed;

                  // this is where you would apply this vector for movement

                  transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)sumOfAiSeperation, separateSpeed * Time.deltaTime);


              }

              //*********************************** END OF NEW SECTION ****************************
      */

        finalAverageMovement = (sumOfAiSeperation + movement).normalized;


        /*

        //manage which animation should play by working out which way the character is facing and moving
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

        */

        float angle = Vector2.SignedAngle(this.transform.up, myRigidbody2d.velocity.normalized);

        if (angle >= -45 && angle < 45)
        {
            animationDirection = "Up";
        }

        else if (angle >= 45 && angle < 135)
        {
            animationDirection = "Right";
        }


        else if (angle > -135 && angle < -45)
        {
            animationDirection = "Left";
        }

        else if (Mathf.Abs(angle) >= 135)
        {
            animationDirection = "Down";
        }

        Debug.Log(angle);


        if (isTakingDamage == true)
            {
                animationAction = "Damage";

                Invoke("Dead", 0.3f);
            }

            else animationAction = "Walk";

            //send the current animation state to the function which tells the animator what to do
            ChangeAnimationState(animationAction + animationFacing + animationDirection);


            previousPosition = transform.position;
        }


        //define direction and speed to move
        void moveEnemyAi(Vector2 finalAverageMovement)
        {
      //  myRigidbody2d.MovePosition((Vector2)transform.position + ((movementTowardsPlayer) * moveSpeed * Time.deltaTime));
        myRigidbody2d.MovePosition((Vector2)transform.position + (finalAverageMovement * moveSpeed * Time.deltaTime));
        
            
    }

    
    //execute movement in fixed update function
    private void FixedUpdate()
    {
        moveEnemyAi(finalAverageMovement);

       
    }



    // tell animator which animation to play
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
