﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class FoodScript : MonoBehaviour
{

    private string gameId = "1574872";

    public static float playerCoins;
    public static float correntLevel;

    // Use this for initialization
    void Start()
    {
        playerCoins = 0;
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, true);
        }

        if (correntLevel != 1)
        {
            correntLevel = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Bug")
        {
            if (Random.Range(1, 3) == 2)
            {
                //show ad
                if (Advertisement.IsReady())
                {
                    Advertisement.Show();
                }
            }
            //set points
            MenuScript.SetMaxedLevel(correntLevel);
            MenuScript.SetCoinsCollected(playerCoins);
            //end game.
            Application.LoadLevel("MainMenu");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("okokok");
    }
}
