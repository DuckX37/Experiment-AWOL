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
    public GameObject cameraSound;

    public playerController playerC;

    public AudioClip basement;

    public bool ion = false;
    public bool vesuvius = false;
    public bool midas = false;
    public bool paused = true;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        playerC = player.GetComponent<playerController>();

        cameraSound = GameObject.Find("Main Camera");
    }


    // Update is called once per frame
    void Update()
    {
        if (!ion && !midas && !vesuvius)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (playerC.health < 100 && playerC.health > 70)
        {
            healthBar.GetComponent<Transform>().localScale = new Vector3(5.907753f, 0.6028796f, 1);
            // healthBar.GetComponent<Transform>().position = new Vector3(0.6418f, -0.64f, -12);
        }
        else if (playerC.health < 70 && playerC.health > 50)
        {
            healthBar.GetComponent<Transform>().localScale = new Vector3(4.854092f, 0.6028796f, 1);
            // healthBar.GetComponent<Transform>().position = new Vector3(0.115f, -0.64f, -12);
        }
        else if (playerC.health < 50 && playerC.health > 20)
        {
            healthBar.GetComponent<Transform>().localScale = new Vector3(3.463394f, 0.6028796f, 1);
            // healthBar.GetComponent<Transform>().position = new Vector3(-0.5804f, -0.64f, -12);
        }
        else if (playerC.health < 20 && playerC.health > 5)
        {
            healthBar.GetComponent<Transform>().localScale = new Vector3(1.356265f, 0.6028796f, 1);
            // healthBar.GetComponent<Transform>().position = new Vector3(-1.634f, -0.64f, -12);
        } else if (playerC.health < 1)
        {
            healthBar.GetComponent<Transform>().localScale = new Vector3(0, 0, 1);
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

        cameraSound.GetComponent<AudioSource>().clip = basement;
        cameraSound.GetComponent<AudioSource>().Play();
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

        cameraSound.GetComponent<AudioSource>().clip = basement;
        cameraSound.GetComponent<AudioSource>().Play();
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

        cameraSound.GetComponent<AudioSource>().clip = basement;
        cameraSound.GetComponent<AudioSource>().Play();
    }

    //Scene Change

   
}
