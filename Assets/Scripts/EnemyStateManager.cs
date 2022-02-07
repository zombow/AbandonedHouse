using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public static EnemyStateManager instance = null;

    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerRay(RaycastHit hitInfo)
    {
        if (hitInfo.transform.gameObject.name == "EnemyBaby")
        {
            EnemyBaby.currentState = "Death";
            //hitInfo.transform.gameObject.GetComponent<EnemyBaby>().Death();
        }
    }
}
