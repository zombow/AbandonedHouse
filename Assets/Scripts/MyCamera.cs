using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public static MyCamera instance;
    public AudioSource audioSource;
    public AudioClip flashsound;
    public GameObject flash;
    public bool isHit;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        isHit = false;
        flash.SetActive(false);
        audioSource.clip = flashsound;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFlash();
    }

    //flash 동작구간
    public void UpdateFlash()
    {
        //Oculuse, VIVE로 교체
        if (Input.GetKeyDown(KeyCode.T))
        {
            audioSource.Play();
            flash.SetActive(true);
            Invoke("waittime", 0.3f);
        }
    }
    void waittime()
    {
        flash.SetActive(false);
    }
    public void HitStatue()
    {
        isHit = true;
    }
}
