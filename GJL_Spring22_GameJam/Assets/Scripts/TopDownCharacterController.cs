using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{
    //make this a singleton class so it can be accessed easily from other classes
    public static TopDownCharacterController instance;


    public Vector3 moveDir;
    public Rigidbody2D myRigidbody2D;
    public Animator animator;
    public Transform attackPointRight;
    public Transform attackPointLeft;
    public Vector2 attackRange = new Vector2 (1, 2);
    public LayerMask enemyLayers;
    public bool isFacingUp = false;
    public bool isFacingRight = true;
    public bool isStandingStill = true;
    public bool isAttackPressed;
    public bool isAttacking;

    // set a delay time (until we know the attack animation is complete) before the character can attack again
    private float attackDelay = 0.3f;

    //set a delay time (until we know the animation is in progress) before the enemies take any damage from the attack
    private float attackDamageDelay = 0.2f;


    public float MOVE_SPEED = 20f;

    private void Awake()
    {

        //here we assign our rigidbody2D compononet to our myRigidBody variable, so that we can make physics changes to our character, like movement
        instance = this;
        
        myRigidbody2D = GetComponent<Rigidbody2D>();

    }

    //use the Update() function for inputs, as it is every frame so inputs will be instant, then use FixedUpdate() for handling physics
    private void Update()

    {
        float moveX = 0f;
        float moveY = 0f;

        // Make sure character is not attacking before accepting inputs for movement
        if (isAttacking == false)
        {


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


        }


        //Attack - here we decide that the "space" key should be used to attack and

        if (Input.GetKeyDown("space"))

        {
            isAttackPressed = true;

        }

        if (isAttackPressed)
        {

            isAttackPressed = false;

            if (!isAttacking)
            {
                isAttacking = true;

            }

            
            Invoke("AttackComplete", attackDelay);
            Invoke("AttackDamage", attackDamageDelay);
          }


    
        
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = moveDir * MOVE_SPEED;

        
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        isFacingRight = !isFacingRight;
    }

    

    // here we create a box which defines the range of the character's weapon, and detect enemies within that box,
    
    void AttackDamage()
    {

        if (isFacingRight == true)
        {


            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPointRight.position, attackRange, 0f, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<OrcScript>().isTakingDamage = true;
                Debug.Log("We hit " + enemy.name);

                
            }
        }

        else
        {

            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPointLeft.position, attackRange, 0f, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<OrcScript>().isTakingDamage = true;
                Debug.Log("We hit " + enemy.name);
            }
        }

        
    }

    // this draws the box (which represents the character's weapon range) in the editor

    private void OnDrawGizmosSelected()
    {
        if (attackPointRight == null && attackPointLeft == null)
            return;
       
        Gizmos.DrawWireCube(attackPointRight.position, attackRange);
        Gizmos.DrawWireCube(attackPointLeft.position, attackRange);
    }


    //this allows the attack animation to play again, by making the isAttacking bool false
    void AttackComplete()
    {

        isAttacking = false;
    }

}
