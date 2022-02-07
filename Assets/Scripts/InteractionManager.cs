using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance = null;
    public static Vector3 BookItemTargetPosition = new Vector3(-2.873f, 3.6356f, -3.2f);

    bool dropPicture;
    bool openStudyRoomDoor;

    public bool PullBookComplete
    {
        get
        {
            if (GameObject.Find("BookItem").transform.position == BookItemTargetPosition)
                return true;
            return false;
        }
    }

    public bool DropPictureComplete
    {
        get
        {
            return dropPicture;
        }
        set
        {
            this.dropPicture = value;
        }
    }

    public bool OpenStudyRoomDoorButtonComplete
    {
        get
        {
            return openStudyRoomDoor;
        }
        set
        {
            this.openStudyRoomDoor = value;
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
