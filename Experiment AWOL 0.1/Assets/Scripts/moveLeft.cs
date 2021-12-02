using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    public float moveSpeed = 1;
    public float leftBound = -75;

    public Rigidbody2D myRB;
 

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        myRB.velocity = new Vector2(-moveSpeed, 0);

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }


    }
}
