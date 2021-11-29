using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scientistController : MonoBehaviour
{
    public GameManager gm;

    public float health = 30;
    public float dmg = 5;

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
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    IEnumerator stunWait()
    {
        yield return new WaitForSeconds(.5f);

    }

}
