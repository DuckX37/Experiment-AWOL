using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityGuardController : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float speed;
    public CircleCollider2D detectionZone;

    Rigidbody2D myRB;
    public GameObject Grappler;
    public Transform player;
    public Vector2 target;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

        myRB = GetComponent<Rigidbody2D>();

        target = new Vector2(player.position.x, player.position.y);

        detectionZone = GetComponent<CircleCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
