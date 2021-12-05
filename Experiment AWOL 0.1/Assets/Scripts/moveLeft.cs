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
        if (gameObject.tag == "Enemy" || gameObject.tag == "purpleVial" || gameObject.tag == "greenVial" || gameObject.tag == "orangeVial" || player.GetComponent<playerController>().stunned || gameObject.name == "Background" || gameObject.tag =="basementExit" ||gameObject.tag == "labsExit" || gameObject.tag == "forestExit")
        {
             myRB.velocity = new Vector2(-moveSpeed, 0);
        }
        
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

       

       //it would be so nice if this worked -cries-

       /*if (!gameObject.tag == "player" || player.GetComponent<playerController>().stunned)
       {
            myRB.velocity = new Vector2(-moveSpeed, 0);
       }
       */
    }

    public void OnCollsionEnter2D (Collision2D collision)
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "purpleVial" || gameObject.tag == "greenVial" || gameObject.tag == "orangeVial")
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());

        }
    }
}
