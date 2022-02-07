using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance = null;
    public static Vector3 BookItemTargetPosition = new Vector3(-2.873f, 3.6356f, -3.2f);
    public static Vector3 OpenDoorButtonTargetPosition = new Vector3(-3.01f, 3.788f, -3.04f);

    public bool PullBookComplete
    {
        get
        {
            if (GameObject.Find("BookItem").transform.position == BookItemTargetPosition)
                return true;
            return false;
        }
    }

    public bool OpenDoorButtonComplete
    {
        get
        {
            if (GameObject.Find("OpenDoorButton").transform.position == OpenDoorButtonTargetPosition)
                return true;
            return false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
