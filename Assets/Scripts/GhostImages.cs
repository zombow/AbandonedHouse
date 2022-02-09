using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostImages : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(image1.transform.position, player.transform.position) <= 5.0f)
        {
            image1.SetActive(true);
            StartCoroutine("WaitForSeconds");
            image2.SetActive(true);
            StartCoroutine("WaitForSeconds");
            image3.SetActive(true);
            StartCoroutine("WaitForSeconds");
            image4.SetActive(true);
            StartCoroutine("WaitForSeconds");
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(2);
    }
}
