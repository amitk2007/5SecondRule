using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public static float maxedLevel;
    public static float coinsColected;
    public static float maxBug;
    public static float maxFood;
    public static float maxBackground;

    public Text ScoreText;
    // Use this for initialization
    void Start()
    {
        coinsColected = PlayerPrefs.GetFloat("coinsColected");
        maxBug = PlayerPrefs.GetFloat("maxBug");
        maxFood = PlayerPrefs.GetFloat("maxFood");
        maxBackground = PlayerPrefs.GetFloat("maxBackground");


        maxedLevel = PlayerPrefs.GetFloat("maxedLevel");
        if (ScoreText.text == "Shop")
        {
            ScoreText.text = "You have " + MenuScript.coinsColected + " coins";
        }
        else
        {
            ScoreText.text = "Your highest level is " + maxedLevel;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetMaxedLevel(float level)
    {
        maxedLevel = Mathf.Max(level, maxedLevel);
        PlayerPrefs.SetFloat("maxedLevel", maxedLevel);
    }

    public static void SetCoinsCollected(float playerCoins)
    {
        coinsColected = coinsColected + playerCoins;
        PlayerPrefs.SetFloat("coinsColected", coinsColected);
    }

    #region buttons

    public void PlayGame()
    {
        Application.LoadLevel("MainGame");
    }
    public void GoToShop()
    {
        Application.LoadLevel("Shop");
    }
    public void GoToSettings()
    {
        Application.LoadLevel("Settings");
    }
    public void GoToMainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
    #endregion
}
