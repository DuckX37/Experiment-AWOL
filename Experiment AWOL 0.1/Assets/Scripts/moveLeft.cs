using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    public float moveSpeed = 1;
    public float leftBound = -75;
 

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }


    }
}
