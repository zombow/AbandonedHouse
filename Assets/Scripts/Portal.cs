using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour
{
    TextMeshPro storyText;
    public GameObject player;

    public GameObject Effect;
    public GameObject GateCollider;

    // Start is called before the first frame update
    void Start()
    {
        storyText = gameObject.GetComponentInChildren<TextMeshPro>();
        //storyText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractionManager.instance.getSuccessMissionCount() == 0)
        {
            SetMessage("왼손 - 후레쉬 \n 오른손 - 아이템 \n" +
                "왼손 트리거 - 상호작용 \n 오른손 트리거 - 아이템 사용하기 \n 오른손 'A' - 아이템 교체 \n 오른손 'B' - 아이템 획득" +
                "\n\n HINT. 손전등으로 아이템 찾아보기");
        }
        
        if (Vector3.Distance(transform.position, player.transform.position) < 1.6f)
        {
            SetMessage("아직은 올라올 수 없어..");
            StartCoroutine("WaitForSeconds");
        }
    }

    private void SetMessage(string message)
    {
        storyText.text = message;
        storyText.enabled = true;
        //TODO : 사운드

    }

    bool isGateOpen = false;
    void GateOpen()
    {
        if (isGateOpen == true)
        {
            Effect.gameObject.SetActive(false);
            //soundCheck = true;
            //SoundManager.instance.GateSound();
            GateCollider.GetComponent<BoxCollider>().enabled = false;

        }
        else
        {
            Effect.gameObject.SetActive(true);
            //soundCheck = false;
            //SoundManager.instance.GateSound();
            GateCollider.GetComponent<BoxCollider>().enabled = true;
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        storyText.enabled = false;
    }
}
