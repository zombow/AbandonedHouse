using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head2 : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion des;
    Quaternion rdes;
    Quaternion origin;
    public FinallEffectManager show;

    AudioSource audioSource;
    public AudioClip audio1;

    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    float currentTime;
    float creatTime = 3f;
    void Start()
    {
        origin = transform.rotation;
        des = transform.rotation * Quaternion.Euler(new Vector3(-40, 0, 0));
        rdes = transform.rotation * Quaternion.Euler(new Vector3(80, 0, 0));
    }
    bool qqqq = true;
    // Update is called once per frame
    void Update()
    {
        if (show != null)
        {
            if (show.Head2Check)
            {

                float a = Quaternion.Angle(origin, transform.rotation);
                print(a);

                if (a >= 20f) qqqq = !qqqq;
                if (qqqq)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, rdes, Time.deltaTime);
                    a = -20f;
                }
                if (!qqqq)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, des, Time.deltaTime);
                    a = -20f;
                }

                audioSource.clip = audio1;
                audioSource.Play();


                //currentTime += Time.deltaTime;

                //transform.rotation = Quaternion.Slerp(transform.rotation, des, Time.deltaTime);

                //if(currentTime > creatTime)
                //{
                //    transform.rotation = Quaternion.Slerp(transform.rotation, rdes, Time.deltaTime);
                //}

                //transform.rotation *= Quaternion.Euler(Vector3.Lerp(new Vector3(-40, 0, 0), new Vector3(40, 0, 0), Time.deltaTime)/100);      
            }
        }
    }
}