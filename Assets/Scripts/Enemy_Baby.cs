using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_Baby : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;
    public Animator anim;
    public float attackDistance = 2f;
    public GameObject teddybear;
    Vector3 startPosition;

    public enum State
    {
        Search,
        Move,
        Attack,
        Death
    }
    public State state;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = State.Search;
        startPosition = transform.position;
        teddybear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Search: UpdateSearch(); break;
            case State.Move: UpdateMove(); break;
            case State.Attack: UpdateAttack(); break;
            case State.Death: UpdateDeath(); break;
            default: break;
        }
    }

    private void UpdateSearch()
    {
        //플레이어를 찾자
        player = GameObject.Find("OVRPlayerController");

        //그다음 하이라이트(1층 화분->인형취득) 이벤트 bool && (여기는 문 없으니 상관없음)로 추가
        //이 아니라 후레시인지되면 움직이기 시작함.
        if (player != null)
        {
            state = State.Move;
            anim.SetTrigger("Move");//이게 animator의 parameter임.
        }
    }

    private void UpdateMove()
    {
        //agent의 도착지는 player다.
        agent.SetDestination(player.transform.position);
        //만약타겟과의 거리가 공격 가능 거리보다 작다면
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < attackDistance)
        {
            //공격상태로 전이하고싶다
            state = State.Attack;
            anim.SetTrigger("Attack");//이게 animator의 parameter임.
        }
    }

    private void UpdateAttack()
    {
        agent.SetDestination(transform.position);
        //agent.isStopped = true;
        //Player이동시 타겟(Player)을 바라보고 싶다(부드럽게 회전임)
        //enemy가 바라볼 방향=타겟-나
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        //targetRotation enemy가 회전할 각도,transform.rotation을 통해 선형보간한다.
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        //transform.rotation을 선형보간(Lerp)한다.
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5);

        ////Gameoverscene 이동
        //SceneManager.LoadScene("GameoverScene");
    }

    //주변콜라이더 범위
    private void OnTrigerEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Doll"))
        {
            UpdateDeath();
            teddybear.SetActive(true);
            Destroy(other.gameObject);
        }
    }
    private void UpdateDeath()
    {
        if (state == State.Death)
        {
            // 함수를 바로 종료하고싶다.
            return;
        }
        state = State.Death;
        anim.SetTrigger("Death");
        agent.SetDestination(startPosition);
    }

    
}
