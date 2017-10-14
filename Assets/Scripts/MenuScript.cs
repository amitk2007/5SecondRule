using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public static float maxedLevel;

    // Use this for initialization
    void Start()
    {
        maxedLevel = PlayerPrefs.GetFloat("maxedLevel");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SetMaxedLevel(float level)
    {
        maxedLevel = level;
        PlayerPrefs.SetFloat("maxedLevel", maxedLevel);
    }

    #region buttons

    public void PlayGame()
    {
        Application.LoadLevel("MainGame");
    }

    #endregion
}
