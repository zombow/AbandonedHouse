using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour
{
    TextMeshPro text;
    public GameObject player;
    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMeshPro>();
        text.enabled = false;
        //portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.6f)
        {
            SetMessage();
        }
    }

    private void SetMessage()
    {
        text.enabled = true;
        //TODO : »ç¿îµå

        StartCoroutine("WaitForSeconds");
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        text.enabled = false;
    }
}
