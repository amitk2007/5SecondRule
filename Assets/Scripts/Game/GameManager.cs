using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    float startTime;
    Vector3 position;
    public float timeDelay;
    public float timeMinus;
    public GameObject[] bugs;
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
            InstantiateBugs();
            startTime = startTime + timeDelay;
            timeDelay = timeDelay - timeMinus;
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
                return cam.ScreenToWorldPoint(new Vector3(UnityRandom(0, width), hight, 0));
            case 2: //down
                return cam.ScreenToWorldPoint(new Vector3(UnityRandom(0, width), 0, 0));
            case 3: //right
                return cam.ScreenToWorldPoint(new Vector3(width, UnityRandom(0, hight), 0));
            case 4: //left
                return cam.ScreenToWorldPoint(new Vector3(0, UnityRandom(0, hight), 0));
            default:
                break;
        }
        return cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        //return new Vector3(0, 0, 0);
    }

    //does not include V2
    private float UnityRandom(float v1, float v2)
    {
        return UnityEngine.Random.Range((int)v1, (int)v2);
    }

    public void InstantiateBugs()
    {
        GameObject bugObject = Instantiate(bugs[UnityEngine.Random.Range(0, bugs.Length)], position, Quaternion.identity);
        if (bugObject.name.Contains("Bacteria"))
        {
            switch (UnityEngine.Random.Range(0, 7))
            {
                case 0:
                    bugObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;
                case 1:
                    bugObject.GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case 2:
                    bugObject.GetComponent<SpriteRenderer>().color = Color.magenta;
                    break;
                case 3:
                    bugObject.GetComponent<SpriteRenderer>().color = Color.green;
                    break;
                case 4:
                    bugObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                    break;
                case 5:
                    bugObject.GetComponent<SpriteRenderer>().color = Color.blue;
                    break;
                case 6:
                    bugObject.GetComponent<SpriteRenderer>().color = new Color(138,43,226);
                    break;
                default:
                    bugObject.GetComponent<SpriteRenderer>().color = Color.white;
                    break;
            }
        }
    }
}
