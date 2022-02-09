using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public static MyCamera instance;
    public AudioSource audioSource;
    public AudioClip flashsound;
    public GameObject flash;

    public float cooltime = 2;
    public bool isHit;
    bool ready = true;
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
        if (Input.GetKeyDown(KeyCode.T) && ready == true)
        {
            ready = false;
            audioSource.Play();
            flash.SetActive(true);
            Invoke("waittime", 0.3f);
        }
    }
    void waittime()
    {
        flash.SetActive(false);
        isHit = false;
        StartCoroutine(CoolTime(cooltime));
    }

    IEnumerator CoolTime (float cool)
    {
        //yield return new WaitForSeconds(3);
        while (cool > 0.1f)
        {
            cool -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        ready = true;
    }
    public void HitStatue()
    {
        isHit = true;
        
    }
}
