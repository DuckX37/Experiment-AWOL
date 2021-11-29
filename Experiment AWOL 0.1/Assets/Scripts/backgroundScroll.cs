using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backgroundScroll : MonoBehaviour
{
    

    private Vector2 startPos;
    private float repeatWidth;
    public int repeatCount = 25;
    // pog
    void Start()
    {
        startPos = transform.position;

        if (SceneManager.GetSceneByName("The Basement").isLoaded)
        {
            repeatWidth = GetComponent<BoxCollider2D>().size.x / 1.5f;
        }
        else if (SceneManager.GetSceneByName("The Labs").isLoaded)
        {
            repeatWidth = GetComponent<BoxCollider2D>().size.x / 2f;
        }
        else if (SceneManager.GetSceneByName("The Forest").isLoaded)
        {
            repeatWidth = GetComponent<BoxCollider2D>().size.x / 1.5f;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
            repeatCount++;
            // Debug.Log("Repeat Count: " + repeatCount);
        }
    }
}
