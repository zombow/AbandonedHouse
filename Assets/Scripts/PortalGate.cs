using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGate : MonoBehaviour
{
    public bool isGateOpen = false;
    public GameObject Effect;
    public GameObject GateCollider;

    bool soundCheck;


    void GateOpen()
    {
        if (isGateOpen == true)
        {
            Effect.gameObject.SetActive(true);
            soundCheck = true;
            //SoundManager.instance.GateSound();
            GateCollider.GetComponent<BoxCollider>().enabled = false;

        }
        else
        {
            Effect.gameObject.SetActive(false);
            soundCheck = false;
            //SoundManager.instance.GateSound();
            GateCollider.GetComponent<BoxCollider>().enabled = true;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GateOpen();
    }
}
