using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public GameObject cam;
    public GameObject headObj;
    public bool head2Check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = cam.transform.TransformDirection(Vector3.forward * 1000);

        if (Physics.Raycast(cam.transform.position, forward, out hit))
        {

            if (hit.transform.tag == "Head2")
            {
                head2Check = true;
            }
            if (hit.transform.tag != "Head2")
            {
                head2Check = false;
            }
        }
    }
}
