using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    public float moveSpeed = 7;
    public float leftBound = -75;
    public Transform playerTarget;

    Rigidbody2D myRB;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.Find("Player").transform;
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookPos = playerTarget.position - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        myRB.rotation = angle;

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
