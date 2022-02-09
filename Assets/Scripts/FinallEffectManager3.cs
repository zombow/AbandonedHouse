using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallEffectManager3 : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip audio1;
    //public AudioClip audio2;

    public GameObject HookHead;
    public GameObject HookHead2;
    public GameObject HookHead3;
    public GameObject HookHead4;
    public GameObject HookHead5;
    public GameObject HookHead6;
    public GameObject HookHead7;

    public FinallEffectManager finallEffectManager;


    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            finallEffectManager.Head2Check = false;
            finallEffectManager.CryingCheck = false;
            finallEffectManager.GetComponent<AudioSource>().enabled = false;

            HookHead.GetComponent<Rigidbody>().isKinematic = false;
            HookHead.GetComponent<Rigidbody>().useGravity = true;
            //audioSource.clip = audio2;
            //audioSource.Play();
            HookHead2.GetComponent<Rigidbody>().isKinematic = false;
            HookHead2.GetComponent<Rigidbody>().useGravity = true;
            //audioSource.clip = audio2;
            //audioSource.Play();
            HookHead3.GetComponent<Rigidbody>().isKinematic = false;
            HookHead3.GetComponent<Rigidbody>().useGravity = true;
            //audioSource.clip = audio2;
            //audioSource.Play();
            HookHead4.GetComponent<Rigidbody>().isKinematic = false;
            HookHead4.GetComponent<Rigidbody>().useGravity = true;
            //audioSource.clip = audio2;
            //audioSource.Play();
            HookHead5.GetComponent<Rigidbody>().isKinematic = false;
            HookHead5.GetComponent<Rigidbody>().useGravity = true;
            //audioSource.clip = audio2;
            //audioSource.Play();
            HookHead6.GetComponent<Rigidbody>().isKinematic = false;
            HookHead6.GetComponent<Rigidbody>().useGravity = true;
            //audioSource.clip = audio2;
            //audioSource.Play();
            HookHead7.GetComponent<Rigidbody>().isKinematic = false;
            HookHead7.GetComponent<Rigidbody>().useGravity = true;
            //audioSource.clip = audio2;
            //audioSource.Play();

        }
    }



    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audio1;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
