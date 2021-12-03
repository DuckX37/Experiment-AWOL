using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    public float moveSpeed = 1;
    public float leftBound = -75;

    public Rigidbody2D myRB;

    public GameObject player;
 

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player (1)");
    }


    void Update()
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "purpleVial" || gameObject.tag == "greenVial" || gameObject.tag == "orangeVial" || player.GetComponent<playerController>().stunned || gameObject.name == "Background")
        {
             myRB.velocity = new Vector2(-moveSpeed, 0);
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

        /*if (player.GetComponent<playerController>().stunned && gameObject.tag == "player")
        {
            moveSpeed = 2;
        }
        else if (gameObject.tag == "player")
        {
            moveSpeed = 0;
        }
        */
    }
}
