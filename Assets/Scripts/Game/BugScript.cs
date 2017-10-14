using UnityEngine;
using System.Collections;

public class BugScript : MonoBehaviour
{
    public GameObject food;
    public float speed;
    public bool isAlive;

    // Use this for initialization
    void Start()
    {
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
    }

    void OnMouseDown()
    {
        Kill(this.gameObject);
        //dead
    }

    void Kill(GameObject toKill)
    {
        isAlive = false;
        this.transform.GetComponent<SpriteRenderer>().color = Color.blue;
    }
}
