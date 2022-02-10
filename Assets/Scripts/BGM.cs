using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource audioPlayer = new AudioSource();
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
