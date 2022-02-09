using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoSkip : MonoBehaviour
{
    float currentTime;
    public float creatTime = 9;



    public void toOpeningScene()
    {
        currentTime += Time.deltaTime;
        if(currentTime > creatTime)
        {
            SceneManager.LoadScene("AbandonedHouse");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toOpeningScene();



    }
    
}
