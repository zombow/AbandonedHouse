using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance = null;
    public GameObject player;

    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        items = GameObject.FindGameObjectsWithTag("GripObject");
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < items.Length; i++)
        //{
        //    if (Vector3.Distance(items[i].transform.position, player.transform.position) <= 2.0f)
        //    {
                
        //    }
        //}
    }

    public void Searching()
    {
        
    }
}
