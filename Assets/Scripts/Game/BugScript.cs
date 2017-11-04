using UnityEngine;
using System.Collections;

public class BugScript : MonoBehaviour
{
    public float bugCoins;

    public GameObject food;
    public float speed;
    public bool isAlive;

    #region after death
    /*public */
    float fadeTime = 1.5f;
    Color origionalColor;
    #endregion

    // Use this for initialization
    void Start()
    {
        food = GameObject.FindGameObjectWithTag("Food");
        isAlive = true;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, food.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, food.transform.position, step);
        }
        else
        {
            this.transform.GetComponent<SpriteRenderer>().color = Color.Lerp(this.transform.GetComponent<SpriteRenderer>().color, origionalColor, fadeTime * Time.deltaTime);
            if (this.transform.GetComponent<SpriteRenderer>().color.a < 0.01)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void OnMouseDown()
    {
        Kill(this.gameObject);
        //dead
    }

    void Kill(GameObject toKill)
    {
        FoodScript.playerCoins = FoodScript.playerCoins + bugCoins;
        isAlive = false;
        this.transform.GetComponent<SpriteRenderer>().color = ToGrayScale(this.transform.GetComponent<SpriteRenderer>().color);
        origionalColor = this.transform.GetComponent<SpriteRenderer>().color;
        origionalColor.a = 0;
    }

    Color ToGrayScale(Color col)
    {
        float avg = (col.r + col.g + col.b) / 3;
        return new Color(avg, avg, avg);
    }
}
