using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallEffectManager : MonoBehaviour
{
    public bool Head2Check;

    AudioSource audioSource;
    public AudioClip audio1;
    public bool CryingCheck;

    public GameObject FinalEffect;

    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Head2Check = true;
            CryingCheck = true;

            FinalEffect.SetActive(true);

            
        }
    }

    public void CryingSound()
    {
        if(CryingCheck == true)
        {
            audioSource.clip = audio1;
            audioSource.Play();
            CryingCheck = false;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CryingSound();
    }
}
