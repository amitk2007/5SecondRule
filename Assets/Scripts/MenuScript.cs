using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public static float maxedLevel;

    public Text ScoreText;
    // Use this for initialization
    void Start()
    {
        maxedLevel = PlayerPrefs.GetFloat("maxedLevel");
        ScoreText.text = "Your highest level is " + maxedLevel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetMaxedLevel(float level)
    {
        maxedLevel =Mathf.Max(level, maxedLevel);
        PlayerPrefs.SetFloat("maxedLevel", maxedLevel);
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
