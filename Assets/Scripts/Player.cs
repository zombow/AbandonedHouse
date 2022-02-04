using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.Background();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        PlaySound();
        GrabItem();
    }

    private void PlaySound()
    {
        if (currentTime > 1)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp)
                || OVRInput.Get(OVRInput.Button.PrimaryThumbstickDown)
                || OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft)
                || OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight))
            {
                SoundManager.instance.FootStep();
                currentTime = 0;
            }
        }
    }

    private void GrabItem()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.Touch) || OVRInput.Get(OVRInput.Button.SecondaryHandTrigger, OVRInput.Controller.Touch))
        {
            GameObject[] items = ItemManager.instance.items;
            try
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (Vector3.Distance(items[i].transform.position, transform.position) <= 1.5f)
                    {
                        Destroy(items[i]);
                        break;
                    }
                }
            } catch (MissingReferenceException e)
            {

            }

            ItemManager.instance.items = GameObject.FindGameObjectsWithTag("GripObject");
        }
    }

}
