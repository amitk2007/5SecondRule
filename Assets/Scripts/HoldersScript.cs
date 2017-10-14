using UnityEngine;
using System.Collections;

public class HoldersScript : MonoBehaviour
{
    #region variables
    public static float correntLevel;
    #endregion

    // Use this for initialization
    void Start()
    {
        if (correntLevel < 1)
        {
            correntLevel = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
