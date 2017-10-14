using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    float startTime;
    Vector3 position;
    public float timeDelay;
    public GameObject bug;
    public Camera cam;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime + timeDelay <= Time.time)
        {
            position = RandomVector3();
            Instantiate(bug, position, Quaternion.identity);
            startTime = startTime + timeDelay;
        }
    }

    private Vector3 RandomVector3()
    {
        float hight = Screen.height;
        float width = Screen.width;
        //cam.ScreenToWorldPoint(Screen.height,Screen.width)
        switch (UnityEngine.Random.Range(1, 5))
        {
            case 1: //up
                return cam.ScreenToWorldPoint(new Vector3(UnityRandom(0,width), hight, 0));
            case 2: //down
                return cam.ScreenToWorldPoint(new Vector3(UnityRandom(0, width), 0, 0));
            case 3: //right
                return cam.ScreenToWorldPoint(new Vector3(width, UnityRandom(0,hight), 0));
            case 4: //left
                return cam.ScreenToWorldPoint(new Vector3(0, UnityRandom(0, hight), 0));
            default:
                break;
        }
        return cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        //return new Vector3(0, 0, 0);
    }

    private float UnityRandom(float v1, float v2)
    {
        return UnityEngine.Random.Range(v1, v2);
    }
}
