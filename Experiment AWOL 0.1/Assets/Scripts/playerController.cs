using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D myRb;

    public int playerSpeed = 3;

    public float jumpForce;
    public float horizontalInput;
    public float gravityMod;
    public int jumpCount = 0;

    public GameManager gm;

    //Player Stats

    public float health;
    public float hitChance;
    public float defenseSoak;
    public float cooldown;
    public float dmg;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityMod;


    }

    // Update is called once per frame
    void Update()
    {
        //player movment code!

        Vector2 velocity = myRb.velocity;

        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontalInput * playerSpeed * Time.deltaTime);

        //Jump code

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!gm.midas && jumpCount <= 2)
            {
                // int jumpCount = 0;
                jumpCount++;
                velocity.y = jumpForce;

               

                if(jumpCount >= 1)
                {
                    //Find a way to see if Midas is on the ground

                }



            }

            velocity.y = jumpForce;
            //Make Vesu and Ion not triple jump!

        }

        myRb.velocity = velocity;


        //Ion Select

        if (gm.ion)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.454902f, 1, 0.6980392f, 1);

            ionSelect();

        }
        else if (gm.midas)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.9339623f, 7163166f, 0.07489321f, 1);

        }
        else if (gm.vesuvius)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.9245283f, 0.1768453f, 0.02180491f, 1);

        }

        
    }

    public void ionSelect()
    {
        health = 100;
        hitChance = 100;
        defenseSoak = 10;
        cooldown = 2;
        dmg = 10;


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
