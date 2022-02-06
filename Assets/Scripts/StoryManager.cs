using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public static StoryManager instance = null;
    public TextMeshPro storyText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        storyText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FirstMemo()
    {
        storyText.text = "teeeee";
        storyText.enabled = true;


    }

}
