using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer3 : MonoBehaviour
{
    public LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    GameObject Button = null;
    public Transform hand;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        // 1. 만약 키보드의 T 버튼을 누르는 중이라면
        if (ControllerManager3.instance.TeleportKey3())
        {
            lr.enabled = true;
            // 1-1. 손의 위치에서 손의 앞뱡항으로 Ray를 쏘고 부딪힌것이 Tower라면 기억하고싶다.
            Ray ray = new Ray(hand.position, hand.forward);
            lr.SetPosition(0, hand.position);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 바라본것이 있는 상황
                lr.SetPosition(1, hitInfo.point);

                if (hitInfo.transform.tag == "Button")
                {
                    hitInfo.transform.GetComponent<Button>().onClick.Invoke();
                }
            }
            else
            {
                // 허공을 보고있는 상황
                lr.SetPosition(1, ray.origin + ray.direction * 100);
            }
        }
        // 2. 그렇지않고 만약 손을 뗏을때
        else if (ControllerManager3.instance.TeleportKeyUp3())
        {
            lr.enabled = false;

            // 2-1. Tower를 기억하고 있었다면 그곳으로 이동하고싶다.
            if (Button != null)
            {

            }
        }
    }
}
