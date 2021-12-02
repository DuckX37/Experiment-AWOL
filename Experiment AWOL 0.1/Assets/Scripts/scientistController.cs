using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scientistController : MonoBehaviour
{
    public GameManager gm;
    public GameObject player;

    public Vector3 playerStun;

    public float health = 30;
    public float dmg = 5;

    public bool stun = false;

    public int stunCount = 0; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);

        }

        if (stun && stunCount == 0)
        {
            playerStun = player.transform.position;
            player.GetComponent<playerController>().stunned = true;

            //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            player.transform.position = playerStun;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine("stunWait");
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("stunWait");
        StopCoroutine("stunDuration");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "rightWall")
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
        }
    }

    IEnumerator stunWait()
    {
        //Debug.Log("aha gotcha bitch!");
        yield return new WaitForSeconds(.0f);
        StartCoroutine("stunDuration");

    }

    IEnumerator stunDuration()
    {
        stun = true;
        stunCount++;
        //Debug.Log("Stun Count: " + stunCount);
        // player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        //Debug.Log("Bzzt");
        yield return new WaitForSeconds(2);
        player.GetComponent<playerController>().stunned = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        stun = false;
    }
}
