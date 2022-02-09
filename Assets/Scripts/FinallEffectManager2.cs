using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinallEffectManager2 : MonoBehaviour
{
    public GameObject FinalEffect1;
    public FinallEffectManager finallEffectManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FinalEffect1.SetActive(true);

            Destroy(this.gameObject);
            //Destroy(finallEffectManager);
            finallEffectManager.FinalEffect.SetActive(false);
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
