using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{

    public static TopDownCharacterController instance;


    public Vector3 moveDir;

    public Rigidbody2D myRigidbody2D;


    public Animator animator;

    public Transform attackPoint;
    public Vector2 attackRange = new Vector2 (1, 2);
    public LayerMask enemyLayers;

    public bool isFacingUp = false;
    public bool isFacingRight = true;
    public bool isStandingStill = true;
    public bool isAttackPressed;
    public bool isAttacking;


    private float attackDelay = 0.3f;
    private float attackDamageDelay = 0.2f;


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

        if (Input.GetKeyDown("space"))

        {
            isAttackPressed = true;

            Debug.Log("ATTACK!");
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

    

    
    void AttackDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
       
        Gizmos.DrawWireCube(attackPoint.position, attackRange);
    }


    void AttackComplete()
    {

        isAttacking = false;
    }

}
