using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance = null;
    public static Vector3 BookItemTargetPosition = new Vector3(-2.873f, 3.6356f, -3.2f);

    bool dropPicture;
    bool openStudyRoomDoor;
    GameObject[] ghostImages;
    Dictionary<GameObject, bool> isShowGhostImage = new Dictionary<GameObject, bool>();

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
        ghostImages = GameObject.FindGameObjectsWithTag("2FGhost");
        for (int i = 0; i < ghostImages.Length; i++)
        {
            isShowGhostImage.Add(ghostImages[i], false);
            ghostImages[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (PullBookComplete && OpenStudyRoomDoorButtonComplete && DropPictureComplete)
        //    Open2Floor();
    }

    private void Open2Floor()
    {
        Destroy(GameObject.Find("Shield"));
    }

    public void SetShowGhostImage(GameObject ghostImage, bool status)
    {
        isShowGhostImage[ghostImage] = status;
    }

    public bool GetShowGhostImage(GameObject ghostImage)
    {
        return isShowGhostImage[ghostImage];
    }
}
