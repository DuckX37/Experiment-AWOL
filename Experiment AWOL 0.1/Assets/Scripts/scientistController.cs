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
        if (health < 0)
        {
            Destroy(gameObject);

        }

        if (stun)
        {
            playerStun = player.transform.position;
            player.GetComponent<playerController>().stunned = true;

            //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            player.transform.position = playerStun;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine("stunWait");
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine("stunWait");
        StopCoroutine("stunDuration");
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
        // player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        Debug.Log("Bzzt");
        yield return new WaitForSeconds(2);
        player.GetComponent<playerController>().stunned = false;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        stun = false;
    }


}
