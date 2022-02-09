using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager3 : MonoBehaviour
{
    public GameObject Button01;
    public GameObject Button02;

    public void toAbandonedHouseScene()
    {
        SceneManager.LoadScene("AbandonedHouseScene");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
