using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityController : MonoBehaviour
{
    public GameManager gm;
    public GameObject player;

    public float health = 70;
    public float dmg = 5;

    public int breakOut = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (breakOut == 0)
        {
            //Stop stun

        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        
    }


    IEnumerator grappleWait()
    {
        yield return new WaitForSeconds(.2f);

    }

}
