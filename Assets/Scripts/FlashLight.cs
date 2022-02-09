using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;
using System;

public class FlashLight : MonoBehaviour
{
    public Transform hand;
    public LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        lr.enabled = false;
    }

    Material lookObjectMat;
    // Update is called once per frame
    void Update()
    {
        RaySth();
    }

    private void ResetMaterial()
    {
        if (lookObjectMat != null)
        {
            lookObjectMat.SetFloat("_Outline", 0);
            lookObjectMat = null;
        }
    }

    private void RaySth()
    {
        Ray ray = new Ray(hand.position, hand.forward);
        RaycastHit hitInfo;
        lr.SetPosition(0, ray.origin);
        if (Physics.Raycast(ray, out hitInfo))
        {
            lr.SetPosition(1, hitInfo.point);
            if (hitInfo.transform.CompareTag("GripObject") || hitInfo.transform.CompareTag("Item"))
            {
                MeshRenderer ren = hitInfo.transform.GetComponent<MeshRenderer>();
                if (ren != null)
                {
                    ResetMaterial();
                    lookObjectMat = ren.material;
                    lookObjectMat.SetFloat("_Outline", 0.01f);
                }
            }
            else
            {
                if (lookObjectMat != null)
                {
                    ResetMaterial();
                }
            }

            if (hitInfo.transform.CompareTag("Enemy"))
            {
                EnemyStateManager.instance.triggerRay(hitInfo);
            }

        }
        else
        {
            lr.SetPosition(1, ray.origin + ray.direction * 20);
        }
    }
}
