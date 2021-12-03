using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneController : MonoBehaviour
{
    public int health = 100;
    public float range;
    public float force;
    public float fireRate;
    public float fireTimer = 0;
    public bool inRange = false;

    public GameObject gun;
    public GameObject bullet;
    public GameObject player;
    public Transform shootPoint;

    public moveLeft left;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        //destroy on death
        if (health < 1)
        {
            Destroy(gameObject);
            inRange = false;
        }

        direction = player.transform.position - transform.position;

        if (inRange)
        {
            gun.transform.up = direction;
            if (Time.time > fireTimer)
            {
                fireTimer = Time.time + 1 / fireRate;
                shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //stops and shoots player
        if (collision.gameObject.tag == "player")
        {
            inRange = true;
            left.moveSpeed = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Moves on when out of range
        if (collision.gameObject.tag == "player")
        {
            inRange = false;
            left.moveSpeed = 5;
        }
    }

    void shoot()
    {
        GameObject b = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        b.GetComponent<Rigidbody2D>().AddForce(direction * force);

        Vector3 lookPos = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        b.GetComponent<Rigidbody2D>().rotation = angle;

        Destroy(b, 4);
    }
}
