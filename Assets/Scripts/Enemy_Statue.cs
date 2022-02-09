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
        if ((player != null)&&(FlashLight.instance.isStatueOnFlash==false))
        {
            currentTime += Time.deltaTime;

            if (currentTime >= posMoveTime)
            {
                transform.position = pos_List[i].position;
                currentTime = 0;
                if (i< (pos_List.Length-1))
                {
                i++;
                }
            }
        }
        //Enemy죽는거 사진기 ray가 Statue맞으면서&&사진찍힘(Flash)일때 Enemy destroy 추가함!!
        else if (MyCamera.instance.isHit==true)
        {
            Destroy(gameObject, 1.0f);
        }

        //마지막 Pos다음으로 i++가 되면 끝나는 거임.
        if (i == (pos_List.Length-1))
        {
            ////Gameoverscene 이동 추가하기
            //SceneManager.LoadScene("GameoverScene");

            Destroy(gameObject,3f);
        }
    }
}
