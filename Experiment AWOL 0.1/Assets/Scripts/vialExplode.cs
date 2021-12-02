using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vialExplode : MonoBehaviour
{
    public float dmg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void OnCollisionEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (gameObject.tag == "purpleVial")
            {
                dmg = Random.Range(1, 20);
                collision.gameObject.GetComponent<playerController>().health -= dmg;
                Destroy(gameObject);
                Debug.Log("Health: " + collision.gameObject.GetComponent<playerController>().health);
            }

            if (gameObject.tag == "greenVial")
            {
                dmg = Random.Range(5, 10);
                collision.gameObject.GetComponent<playerController>().health -= dmg;
                Destroy(gameObject);
                Debug.Log("Health: " + collision.gameObject.GetComponent<playerController>().health);
            }

            if (gameObject.tag == "orangeVial")
            {
                dmg = Random.Range(10, 15);
                collision.gameObject.GetComponent<playerController>().health -= dmg;
                Destroy(gameObject);
                Debug.Log("Health: " + collision.gameObject.GetComponent<playerController>().health);
            }

        }
        
    }
    */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "rightWall")
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
        }

        if (collision.gameObject.tag == "player")
        {
            if (gameObject.tag == "purpleVial")
            {
                dmg = Random.Range(1, 20);
                collision.gameObject.GetComponent<playerController>().health -= dmg;
                Destroy(gameObject);
                Debug.Log("Health: " + collision.gameObject.GetComponent<playerController>().health);
            }

            if (gameObject.tag == "greenVial")
            {
                dmg = Random.Range(5, 10);
                collision.gameObject.GetComponent<playerController>().health -= dmg;
                Destroy(gameObject);
                Debug.Log("Health: " + collision.gameObject.GetComponent<playerController>().health);
            }

            if (gameObject.tag == "orangeVial")
            {
                dmg = Random.Range(10, 15);
                collision.gameObject.GetComponent<playerController>().health -= dmg;
                Destroy(gameObject);
                Debug.Log("Health: " + collision.gameObject.GetComponent<playerController>().health);
            }

        }
        
    }
}
