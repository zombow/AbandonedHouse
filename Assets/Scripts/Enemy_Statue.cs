using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Statue : MonoBehaviour
{
    public Transform[] pos_List;
    public float posMoveTime = 1.5f;
    public GameObject player;
    public bool isStatueCameraShot;

    private float currentTime;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos_List[0].position;
        player = GameObject.Find("OVRPlayerController");
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //player 존재하고 화장실문이 열리는 이벤트 bool신호되면 움직이기 시작 나중에 &&로 조건달아주기
        if (!FlashLight.instance.IsStatueOnFlash)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= posMoveTime)
            {
                transform.position = pos_List[i].position;
                SoundPlay();
                currentTime = 0;
                if (i < (pos_List.Length - 1))
                {
                    i++;
                }
            }
        }

        //Enemy죽는거 사진기 ray가 Statue맞으면서&&사진찍힘(Flash)일때 Enemy destroy 추가함!!
        if (MyCamera.instance.isHit==true)
        {
            Instantiate(Resources.Load("Prefabs/StoneBaby_Red"), transform.position + Vector3.up * 1.2f, transform.rotation);
            //Destroy(gameObject, 1.0f);
            gameObject.SetActive(false);
            //Invoke("GetItem", 1f);
        }
    }

    private void GetItem()
    {
        Destroy(gameObject);

    }

    private void SoundPlay()
    {
        AudioSource audioPlayer = GetComponent<AudioSource>();
        audioPlayer.Play();
    }
}
