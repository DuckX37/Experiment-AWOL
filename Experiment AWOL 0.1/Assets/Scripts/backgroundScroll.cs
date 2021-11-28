using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagment;

public class backgroundScroll : MonoBehaviour
{
    

    private Vector2 startPos;
    private float repeatWidth;
    public int repeatCount = 25;
    // pog
    void Start()
    {
        startPos = transform.position;

        if (SceneManager.GetSceneByName("The Basement".isLoaded))
        {
            repeatWidth = GetComponent<BoxCollider2D>().size.x / 1.5f;
        }
        else if (SceneManager.GetSceneByName("The Labs".isLoaded))
        {
            repeatWidth = GetComponent<BoxCollider2D>().size.x / 1.2f;
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
