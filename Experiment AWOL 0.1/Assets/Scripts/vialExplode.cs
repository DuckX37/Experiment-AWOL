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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "purpleVial")
        {
            dmg = Random.Range(1, 20);

        }
    }
}
