using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private Rigidbody2D myRb;

    public int playerSpeed = 3;
    public int laserCount = 20;

    public float laserLifesSpan = 2.5f;

    public float jumpForce;
    public float horizontalInput;
    public float gravityMod;
    public int jumpCount = 0;

    public GameManager gm;

    //Player Stats

    public float health = 100;
    public float hitChance;
    public float defenseSoak;
    public float cooldown;
    public float dmg;

    // cooldowns
    public bool laserCooldownOn = false;

    public bool explosionCooldownOn = false;

    public bool rushCooldownOn = false;

    public bool stunned = false;

    //player specific variables
    public GameObject beam;
    public GameObject laser;

    public GameObject vesuExplosion;

    public GameObject midasRush;


    public BoxCollider2D playerBody;

    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityMod;

        playerBody = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //player movment code!

        Vector2 velocity = myRb.velocity;

        horizontalInput = Input.GetAxis("Horizontal");

        if (!stunned)
            transform.Translate(Vector2.right * horizontalInput * playerSpeed * Time.deltaTime);

        //Jump code

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Jump Count code for Ion and Vesu
            if (!gm.midas && jumpCount < 2)
            {
                jumpCount++;
                velocity.y = jumpForce;
            }

            //Jump Count code for Midas
            if (gm.midas && jumpCount < 1)
            {
                jumpCount++;
                velocity.y = jumpForce;
            }



        }




        myRb.velocity = velocity;



        if (gm.ion)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.454902f, 1, 0.6980392f, 1);

            ionSelect();

        }
        else if (gm.midas)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.9339623f, 7163166f, 0.07489321f, 1);

            midasSelect();
        }
        else if (gm.vesuvius)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.9245283f, 0.1768453f, 0.02180491f, 1);

            vesuviusSelect();
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            jumpCount = 0;
        }
    }


    public void ionSelect()
    {
        // health = 100;
        hitChance = 100;
        defenseSoak = 0;
        cooldown = 2;
        dmg = 10;

        float laserSpeed = 15f;

        if (Input.GetKeyDown(KeyCode.P) && !laserCooldownOn)
        {
            laserCount--;
            // Debug.Log("Laser Count: " + laserCount);

            GameObject l = Instantiate(laser, transform);
            l.GetComponent<Rigidbody2D>().velocity = new Vector2(laserSpeed, 0);
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), l.GetComponent<BoxCollider2D>());

            Destroy(l, laserLifesSpan);

        }

        if (laserCount == 0)
        {
            StartCoroutine("LaserRefill");
            laserCount = 20;
        }

        //special beam move
        if (Input.GetKeyDown(KeyCode.S))
        {
            beam.SetActive(true);
            StartCoroutine("BeamDuration");
            // StartCoroutine("BeamCooldown");
        }
    }

    //Cooldowns for Ion

    IEnumerator LaserRefill()
    {
        laserCooldownOn = true;
        Debug.Log("Cooldown in progress...");
        yield return new WaitForSeconds(5);
        laserCooldownOn = false;
        Debug.Log("Good to go!");
    }

    IEnumerator BeamDuration()
    {
        Debug.Log("LONG ASS LASER BEAM");
        yield return new WaitForSeconds(4);
        beam.SetActive(false);
        StartCoroutine("BeamCooldown");
    }

    IEnumerator BeamCooldown()
    {
        Debug.Log("Cooldown for beam in progress...");
        yield return new WaitForSeconds(30);
    }

    public void midasSelect()
    {
        // health = 100;
        hitChance = 100;
        defenseSoak = 5;
        cooldown = 20;
        dmg = 10;

        // placeholder hurt code
        if (Input.GetKeyDown(KeyCode.H))
        {
            health = health - 10;
        }


        if (Input.GetKeyDown(KeyCode.S) && !rushCooldownOn)
        {
            StartCoroutine("BullRushDuration");
        }


    }

    IEnumerator BullRushDuration()
    {
        Debug.Log("Woosh!");
        midasRush.SetActive(true);
        yield return new WaitForSeconds(5);
        midasRush.SetActive(false);
        rushCooldownOn = true;
        StartCoroutine("BullRushCooldown");

    }

    IEnumerator BullRushCooldown()
    {
        Debug.Log("Cooldown");
        midasRush.SetActive(false);
        yield return new WaitForSeconds(15);
        rushCooldownOn = false;
    }




    public void vesuviusSelect()
    {

        // health = 100;
        hitChance = 100;
        defenseSoak = 0;
        cooldown = 20;
        dmg = 10;

        //Punch is in Enemy controller

        if (Input.GetKeyDown(KeyCode.S) && !explosionCooldownOn)
        {
            StartCoroutine("ExplosionDuration");
        }

    }

    IEnumerator ExplosionDuration()
    {
        Debug.Log("BOOM");
        vesuExplosion.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        vesuExplosion.SetActive(false);
        explosionCooldownOn = true;
        StartCoroutine("ExplosionCooldown");
    }

    IEnumerator ExplosionCooldown()
    {
        Debug.Log("Explosion Cooldown in progress...");
        yield return new WaitForSeconds(10);
        explosionCooldownOn = false;
        Debug.Log("Good to go!");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gm.ion)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                collision.gameObject.GetComponent<scientistController>().health -= dmg;
                Debug.Log("Pow");
            }

        }
       
    }

    public void OnCollisionEnter2D(Collider2D collision)
    {
        //Pickup Script

        if (collision.gameObject.tag == "healthPickup")
        {
            health += 20;
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.tag == "defensePickup")
        {
            defenseSoak += 5;
            Destroy(collision.gameObject);
            StartCoroutine("picupDuration");
            defenseSoak -= 5;


        }

        if (collision.gameObject.tag == "dmgPickup")
        {
            dmg += 15;
            Destroy(collision.gameObject);
            StartCoroutine("pickupDuration");
            dmg -= 15;
        }

        //Level change

        if (collision.gameObject.tag == "basementExit")
        {
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.tag == "labsExit")
        {
            SceneManager.LoadScene(3);
        }

        if (collision.gameObject.tag == "forestExit")
        {
            SceneManager.LoadScene(4);
        }
    }

    //pickup duration script

    IEnumerator pickupDuration()
    {
        yield return new WaitForSeconds(5);
    }

  
}

