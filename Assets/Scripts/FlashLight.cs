using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;
using System;

public class FlashLight : MonoBehaviour
{
    public Transform hand;
    public LineRenderer lr;

    public static FlashLight instance;

    private float currentTime;
    public float zombieDestroyTime = 3.0f;
    public bool isZombieDestroyTimeOver;
    public bool isStatueOnFlash;

    public bool zombie1Death;
    public bool zombie2Death;
    public bool zombie3Death;

    public bool IsStatueOnFlash
    {
        get { return isStatueOnFlash; }
        set { isStatueOnFlash = value; }
    }
    private void Awake()
    {
        instance = this;
    }

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

            if (GameObject.Find("Spotlight and Beam").GetComponent<Light>().color == Color.blue)
            {
                if (hitInfo.transform.gameObject.name == "Enemy_Zombie")
                {
                    currentTime += Time.deltaTime;
                    if (currentTime >= zombieDestroyTime)
                    {
                        EnemyManager.instance.SetEnemyState(1, EnemyManager.State.Death);
                        currentTime = 0;
                    }
                } 
                else if (hitInfo.transform.gameObject.name == "Enemy_Zombie2nd")
                {
                    currentTime += Time.deltaTime;
                    if (currentTime >= zombieDestroyTime)
                    {
                        EnemyManager.instance.SetEnemyState(2, EnemyManager.State.Death);
                        currentTime = 0;
                    }
                }
                else if (hitInfo.transform.gameObject.name == "Enemy_Zombie3rd")
                {
                    currentTime += Time.deltaTime;
                    if (currentTime >= zombieDestroyTime)
                    {
                        EnemyManager.instance.SetEnemyState(3, EnemyManager.State.Death);
                        currentTime = 0;
                    }
                }
            }

            //Statue 후레쉬 맞으며 사진찍여야함.
            if (hitInfo.transform.gameObject.name == "Enemy_Statue")
            {
                //isStatueOnFlash = true;
                IsStatueOnFlash = true;
            }
            else
            {
                //isStatueOnFlash = false;
                IsStatueOnFlash = false;
            }
        }
        else
        {
            lr.SetPosition(1, ray.origin + ray.direction * 20);
        }
    }
}
