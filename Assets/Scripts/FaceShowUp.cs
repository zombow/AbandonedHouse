using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceShowUp : MonoBehaviour
{
    public bool Head2Check;
    public GameObject player;
    GameObject[] ghostImages;

    public GameObject[] heads;

    Dictionary<GameObject, GameObject> ghostImagesAndHeads = new Dictionary<GameObject, GameObject>();
    
    Quaternion des;
    Quaternion rdes;
    Quaternion origin;

    float currentTime;
    float creatTime = 3f;

    // Start is called before the first frame update
    void Start()
    {

        ghostImages = GameObject.FindGameObjectsWithTag("2FGhost");

        for (int i = 0; i < ghostImages.Length; i++)
        {
            ghostImagesAndHeads.Add(ghostImages[i], heads[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Attraction();

        //if (heads[i] != null)
        //    heads[i].GetComponent<Head2>().ShakeHead();
        for (int i = 0; i < ghostImages.Length; i++)
        {
            if (ghostImagesAndHeads[ghostImages[i]] != null
                && InteractionManager.instance.GetShowGhostImage(ghostImages[i]))
            {
                print("!!!!!");
                ghostImagesAndHeads[ghostImages[i]].GetComponent<Head2>().ShakeHead();
            }
        }
    }

    void Attraction()
    {
        //if (Vector3.Distance(transform.position, player.transform.position) < 5.0f
        //    && !InteractionManager.instance.GetShowGhostImage(gameObject))
        //{
        //    this.gameObject.SetActive(true);
        //    SoundManager.instance.GirlSc();
        //    InteractionManager.instance.SetShowGhostImage(gameObject, true);
        //}

        for (int i = 0; i < ghostImages.Length; i++)
        {
            if (Vector3.Distance(ghostImages[i].transform.position, player.transform.position) < 4.0f
                && !InteractionManager.instance.GetShowGhostImage(ghostImages[i]))
            {
                ghostImages[i].SetActive(true);
                SoundManager.instance.GirlSc();
                InteractionManager.instance.SetShowGhostImage(ghostImages[i], true);
                break;
            }
        }
    }

    //bool qqqq = true;
    //public void ShakeHead(GameObject head)
    //{
    //    float a = Quaternion.Angle(origin, transform.rotation);

    //    if (a >= 20f) qqqq = !qqqq;
    //    if (qqqq)
    //    {
    //        head.transform.rotation = Quaternion.Slerp(transform.rotation, rdes, Time.deltaTime);
    //        a = -20f;
    //    }
    //    if (!qqqq)
    //    {
    //        head.transform.rotation = Quaternion.Slerp(transform.rotation, des, Time.deltaTime);
    //        a = -20f;
    //    }


    //    currentTime += Time.deltaTime;

    //    head.transform.rotation = Quaternion.Slerp(head.transform.rotation, des, Time.deltaTime);

    //    if (currentTime > creatTime)
    //    {
    //        head.transform.rotation = Quaternion.Slerp(head.transform.rotation, rdes, Time.deltaTime);
    //    }

    //    head.transform.rotation *= Quaternion.Euler(Vector3.Lerp(new Vector3(-40, 0, 0), new Vector3(40, 0, 0), Time.deltaTime) / 100);
    //}
}
