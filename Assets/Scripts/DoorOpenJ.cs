using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpenJ : MonoBehaviour
{
    public Animator anim;
    public bool isOpen = false;
    public bool check = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player" && check == true)
        {
            SceneManager.LoadScene("MenuScene");
            //anim.SetTrigger("Open");
            //isOpen = false;
        }
    }

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
            check = true;
        }
    }
}
