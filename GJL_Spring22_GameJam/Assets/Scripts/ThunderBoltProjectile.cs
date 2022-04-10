using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBoltProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;


    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();   
    }

    void update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)

    {
        Destroy(gameObject);
    }


}
