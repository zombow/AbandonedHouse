using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float currentTime;

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
                    if (Vector3.Distance(items[i].transform.position, transform.position) <= 3f)
                    {
                        if (items[i].gameObject.name.Equals("BookItem") && !InteractionManager.instance.PullBookComplete)
                        {
                            items[i].transform.position = Vector3.Lerp(items[i].transform.position, InteractionManager.BookItemTargetPosition, 0.5f);
                        }
                        else if (items[i].gameObject.name.Equals("Picture_7 (1)") && !InteractionManager.instance.DropPictureComplete)
                        {
                            Animation anim = items[i].gameObject.GetComponent<Animation>();
                            anim.Play("DropPicture");
                            InteractionManager.instance.DropPictureComplete = true;

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
            } catch (MissingReferenceException e)
            {

            }
        }
    }

}
