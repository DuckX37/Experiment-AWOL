using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneScript : MonoBehaviour
{
    public int health = 100;
    public float speed = 5.0f;
    public float lazer = 7.0f;
    public float fireTimer = 0;
    public float fireCooldown = 1;
    public bool inRange = false;
    public bool canFire = true;

    public Vector2 velocity;
    public Vector2 playerPos;
    public moveLeft left;
    public GameObject bullet;
    public Transform playerTarget;

    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

        playerTarget = GameObject.Find("Player").transform;

        velocity = new Vector3(-lazer, -2);
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            Destroy(gameObject);
            inRange = false;
        }

        if (inRange && canFire)
        {
            //fire
            GameObject b = Instantiate(bullet, transform.position, transform.rotation);
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), b.GetComponent<BoxCollider2D>());
            b.GetComponent<Rigidbody2D>().velocity = velocity;

            Vector3 lookPos = playerTarget.position - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            b.GetComponent<Rigidbody2D>().rotation = angle;

            canFire = false;
        }

        if(!canFire)
        {
            fireTimer += Time.deltaTime;

            if(fireTimer >= fireCooldown)
            {
                fireTimer = 0;
                canFire = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inRange = true;
            left.moveSpeed = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            inRange = false;
            left.moveSpeed = 5;
        }
    }
}
