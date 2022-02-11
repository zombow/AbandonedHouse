using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallHall : MonoBehaviour
{
    public DoorOpenJ doorOpenJ;
    public GameObject smoke;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            doorOpenJ.isOpen = true;
            smoke.SetActive(true);
            
        }
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
