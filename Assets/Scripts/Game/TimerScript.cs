using UnityEngine;
using System.Collections;
using System;

public class TimerScript : MonoBehaviour
{
    float startTime;
    public GameObject levelText;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }
        
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMesh>().text = (Time.time - startTime).ToString("f2");
        if (Time.time - startTime >= 5f)
        {
            FoodScript.correntLevel++;
            startTime = Time.time;
            ShowText(levelText, FoodScript.correntLevel);
        }
    }

    void ShowText(GameObject lable, float level)
    {
        lable.GetComponent<TextMesh>().text = "Level " + level;
        lable.transform.localScale = new Vector3(1, 1, 1);
        lable.SetActive(true);
        fadeAway(lable);
    }

    void fadeAway(GameObject lable)
    {
        //animation

/*        float thistime = Time.time;
        float toShort = 0.1f;
        int i = 0;
        while (Time.time <= thistime + 1)
        {
            //60/1/toShort -> 60*toShort
            if (Time.time - thistime >= 60 * toShort * i)
            {
                lable.transform.localScale = new Vector3(lable.transform.localScale.x - toShort, lable.transform.localScale.y - toShort, 1);
                i++;
            }
        }
        */
    }/*not working*/
}
