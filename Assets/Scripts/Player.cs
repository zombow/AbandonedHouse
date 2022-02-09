using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currentTime;
    int idx = 0;

    // Start is called before the first frame update
    void Start()
    {
        //TODO : BGM empty object 만들어서 배경음악 입혀야함
        //SoundManager.instance.Background();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        PlaySound();
        Interaction();
        GetItem();
        ChangeFlashLightColor();
        ChangeItem();
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

    private void Interaction()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.Touch))
        {
            GameObject[] items = ItemManager.instance.items;
            for (int i = 0; i < items.Length; i++)
            {
                if (Vector3.Distance(items[i].transform.position, transform.position) <= 3f)
                {
                    if (items[i].gameObject.name.Equals("BookItem") && !InteractionManager.instance.PullBookComplete)
                    {
                        items[i].transform.position = Vector3.Lerp(items[i].transform.position, InteractionManager.BookItemTargetPosition, 0.5f);
                        ItemManager.instance.battery.SetActive(true);
                    }
                    else if (items[i].gameObject.name.Equals("Picture_7 (1)") && !InteractionManager.instance.DropPictureComplete)
                    {
                        Animation anim = items[i].gameObject.GetComponent<Animation>();
                        anim.Play("DropPicture");
                        InteractionManager.instance.DropPictureComplete = true;

                        ItemManager.instance.killCamera.SetActive(true);

                        GameObject toiletDoor = GameObject.Find("ToiletDoor");
                        Animation anim2 = toiletDoor.GetComponent<Animation>();
                        anim2.Play("OpenToiletDoor");

                        AudioSource audio = toiletDoor.GetComponent<AudioSource>();
                        audio.transform.position = toiletDoor.transform.position;
                        audio.Play();
                    }
                    break;
                }
            }
        }

        
    }

    private void ChangeFlashLightColor()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger, OVRInput.Controller.Touch)) 
        {
            if (ItemManager.instance.GetActiveGameObject("Battery"))
                GameObject.Find("FlashLight").GetComponent<Light>().color = Color.blue;
                return;
        }
        GameObject.Find("FlashLight").GetComponent<Light>().color = Color.white;
        
    }

    private void ChangeItem()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            ChangeInventory();
            ItemManager.instance.ActiveItem();
        }
    }

    private void GetItem()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (ItemManager.instance.battery != null
                && ItemManager.instance.battery.activeInHierarchy
                && Vector3.Distance(ItemManager.instance.battery.transform.position, transform.position) <= 3f)
            {
                ItemManager.instance.AddGainItems("Battery");
                ItemManager.instance.ActiveItem("Battery");
                Destroy(ItemManager.instance.battery);
            }

            if (ItemManager.instance.killCamera != null
                && ItemManager.instance.killCamera.activeInHierarchy
                && Vector3.Distance(ItemManager.instance.killCamera.transform.position, transform.position) <= 3f)
            {
                ItemManager.instance.AddGainItems("Camera");
                ItemManager.instance.ActiveItem("Camera");
                Destroy(ItemManager.instance.killCamera);
            }

            if (ItemManager.instance.doll != null
                && ItemManager.instance.doll.activeInHierarchy
                && Vector3.Distance(ItemManager.instance.doll.transform.position, transform.position) <= 3f)
            {
                ItemManager.instance.AddGainItems("Doll");
                ItemManager.instance.ActiveItem("Doll");
                Destroy(ItemManager.instance.doll);
            }
        }
    }

    private void ChangeInventory()
    {
        if (idx < ItemManager.instance.GainItemCount() - 1) idx++;
        else idx = 0;
    }
}
