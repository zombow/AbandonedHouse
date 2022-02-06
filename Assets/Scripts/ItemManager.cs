using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance = null;
    public GameObject player;

    public GameObject[] items;
    public GameObject[] doorObjects;
    public string destroyItem;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        items = GameObject.FindGameObjectsWithTag("GripObject");
        doorObjects = GameObject.FindGameObjectsWithTag("Door");
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyItem != null && destroyItem == "BookItem")
        {
            for (int i = 0; i < doorObjects.Length; i++)
            {
                if (doorObjects[i].name.Equals("StudyRoomDoor"))
                {
                    Animation anim = doorObjects[i].GetComponent<Animation>();
                    AudioSource audio = doorObjects[i].GetComponent<AudioSource>();
                    audio.transform.position = doorObjects[i].transform.position;
                    anim.Play("OpenDoor");
                    audio.Play();
                    destroyItem = null;
                    break;
                }
            }
        }
    }


}
