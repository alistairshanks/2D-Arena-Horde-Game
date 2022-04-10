using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBoltProjectileSpawner : MonoBehaviour

{ 
	[SerializeField]
	int numberOfProjectiles;

	[SerializeField]

    GameObject projectile;

    Vector2 startPoint;

    float radius, moveSpeed;

	public static ThunderBoltProjectileSpawner instance;

	public bool ThunderIsPressed;

	public bool ThunderAttack;
	


   void Start()

              {
	            radius = 5f;
	            moveSpeed = 5f;
               }

	


   void Update()
     {
	    if (Input.GetButtonDown("Fire1"))
	       {
			startPoint = GameObject.Find("Player").transform.position;

		    SpawnProjectiles(numberOfProjectiles);

			ThunderIsPressed = true;

	       }

		if(ThunderIsPressed)
        {
			ThunderIsPressed = false;

			if(!ThunderAttack)
            {
				ThunderAttack = true;
            }
        }
		


     }



   void SpawnProjectiles(int numberOfProjectiles)
     {
	     float angleStep = 360f / numberOfProjectiles;

	     float angle = 0f;

	       for (int i = 0; i <= numberOfProjectiles - 1; i++)
	         
		{

		    float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
		    float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

     		Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
	    	Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized * moveSpeed;

		    var proj = Instantiate(projectile, startPoint, transform.rotation);

		    proj.GetComponent<Rigidbody2D>().velocity =

			new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

			proj.transform.Rotate(0, 0, Mathf.Atan2(projectileMoveDirection.y, projectileMoveDirection.x) * Mathf.Rad2Deg);

			angle += angleStep;
	     }
      }

	void ThunderComplete()
    {
		ThunderAttack = false;
    }
   
}



