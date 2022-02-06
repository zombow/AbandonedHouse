using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager instance = null;
    public bool pullBook;

    // TODO : flashlight 비출 때 이미 인터렉션 끝난 오브젝트는 셰이더 벗겨야함
    public bool PullBook
    {
        get { return pullBook; }
        set { this.pullBook = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
