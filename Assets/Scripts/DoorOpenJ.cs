using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenJ : MonoBehaviour
{
    public Animator anim;
    public bool isOpen = false;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(gameObject.transform.tag == "Player" && isOpen == true)
    //    {
    //        anim.SetTrigger("Open");
    //        isOpen = false;
    //    }
    //}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true)
        {
            anim.SetTrigger("Open");
            isOpen = false;
        }
    }
}
