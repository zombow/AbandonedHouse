using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shield : MonoBehaviour
{
    TextMeshPro text;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMeshPro>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        text.enabled = true;
        //TODO : »ç¿îµå
        SoundManager.instance.GetItem();
        StartCoroutine(WaitForSeconds());
        text.enabled = false;
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
    }
}
