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

        if (stun)
        {
            playerStun = player.transform.position;
            player.GetComponent<playerController>().stunned = true;

            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            player.transform.position = playerStun;
        }
    }

   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
            StartCoroutine("stunDuration");

        if (collision.gameObject.name == "rightWall")
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
        }
    }

    IEnumerator stunWait()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine("stunDuration");

    }

    IEnumerator stunDuration()
    {
        stun = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        player.GetComponent<playerController>().health -= dmg;
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<playerController>().stunned = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        stun = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("ionLaser") || collision.gameObject.name == "ionBeam"
            || collision.gameObject.name == "vesuExplosion" || collision.gameObject.name == "midasRush")
        {
            Debug.Log("I'm taking damage!!! ouch");
            // health = health - player.GetComponent<playerController>().dmg;
            health = health - 5;
        }
    }
}
