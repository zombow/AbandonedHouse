using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceShowUp : MonoBehaviour
{
    public GameObject cam;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Head;
    public bool Head2Check;
    public GameObject player;

    void Attraction()
    {
        if (Vector3.Distance(Image1.transform.position, player.transform.position) < 3.0f)
        {
            Image1.SetActive(true);
            SoundManager.instance.GirlSc();
        }
        //RaycastHit hit;
        //Vector3 forward = cam.transform.TransformDirection(Vector3.forward * 1000);

        //if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
        //{
        //    print(hit.transform.gameObject);
        //    if (hit.transform.gameObject.tag == "2FGhost")
        //    //if (hit.transform.gameObject.name == Image1.name)
        //    {
        //        //Image1.SetActive(true);
        //        hit.transform.gameObject.SetActive(true);
        //        SoundManager.instance.GirlSc();
        //    }

        //    //if (hit.transform.gameObject.name == Image2.name)
        //    //{
        //    //    Image2.SetActive(true);
        //    //    SoundManager.instance.GirlSc();
        //    //}

        //    if(hit.transform.tag == "Head")
        //    {
        //        print(2);
        //        //Head.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), Time.deltaTime);
        //        //Head.transform.position = Vector3.Lerp(Head.transform.position, new Vector3(0, 0, 0.5f), Time.deltaTime);
        //        Head.GetComponent<Rigidbody>().isKinematic = false;
        //        Head.GetComponent<Rigidbody>().useGravity = true;
        //    }

        //    if(hit.transform.tag == "Head2")
        //    {
        //        Head2Check = true;
        //        print(Head2Check);
        //    }

        //}
    }





    // Start is called before the first frame update
    void Start()
    {
        Image1.SetActive(false);
        Image2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Attraction();
    }
}
