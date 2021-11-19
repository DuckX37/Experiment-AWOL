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
