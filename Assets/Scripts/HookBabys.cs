using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HookBabys : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    public NavMeshAgent agent;
    public Animator anim;

    AudioSource audioSource;
    public AudioClip soundMonsterAttack;

    Rigidbody rb;

    bool movestart;

    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Floor")
        {
            audioSource.clip = soundMonsterAttack;
            audioSource.Play();

            movestart = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        AgnetMove();
    }
    void AgnetMove()
    {
            if (player != null && movestart == true)
            {
                anim.SetTrigger("Move");
                agent.destination = player.transform.position;
                agent.transform.LookAt(player.transform.position);
            }

    }

}
