using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject vesuviusButton;
    public GameObject ionButton;
    public GameObject midasButton;
    public GameObject player;
    public GameObject Title;
    public GameObject healthBar;

    public playerController playerC;

    public bool ion = false;
    public bool vesuvius = false;
    public bool midas = false;
    public bool paused = true;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!ion && !midas && !vesuvius)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }

        if (playerC.health < 100 && playerC.health > 70)
        {
            healthBar.GetComponent<Transform>().localScale = new Vector3(6.21198f, 0.6028796f, 1);
        }
        else if (playerC.health < 70 && playerC.health > 50)
        {
            healthBar.GetComponent<Transform>().localScale = new Vector3(5.260305f, 0.6028796f, 1);
        }
        else if (playerC.health < 50 && playerC.health > 20)
        {
            healthBar.GetComponent<Transform>().localScale = new Vector3(3.416042f, 0.6028796f, 1);
        }
        else if (playerC.health < 20 && playerC.health > 5)
        {
            healthBar.GetComponent<Transform>().localScale = new Vector3(1.43303f, 0.6028796f, 1);
        }
    }
    

    public void ionSelect()
    {
        ion = true;
        midas = false;
        vesuvius = false;


        GameObject.Find("vesuviusSelectButton").SetActive(false);
        GameObject.Find("ionSelectButton").SetActive(false);
        GameObject.Find("midasSelectButton").SetActive(false);
        GameObject.Find("Text").SetActive(false);
        GameObject.Find("Image").SetActive(false);
    }

    public void midasSelect()
    {
        midas = true;
        ion = false;
        vesuvius = false;

        GameObject.Find("vesuviusSelectButton").SetActive(false);
        GameObject.Find("ionSelectButton").SetActive(false);
        GameObject.Find("midasSelectButton").SetActive(false);
        GameObject.Find("Text").SetActive(false);
        GameObject.Find("Image").SetActive(false);
    }

    public void vesuviusSelect()
    {
        vesuvius = true;
        ion = false;
        midas = false;

        GameObject.Find("vesuviusSelectButton").SetActive(false);
        GameObject.Find("ionSelectButton").SetActive(false);
        GameObject.Find("midasSelectButton").SetActive(false);
        GameObject.Find("Text").SetActive(false);
        GameObject.Find("Image").SetActive(false);
    }
}
