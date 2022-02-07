using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaby : MonoBehaviour, Enemy
{
    public static string currentState = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == "Move")
        {
            Move();
        } else if (currentState == "Death")
        {
            Death();
        }
    }

    public void Death()
    {
        print("Death");
    }

    public void Move()
    {
        print("Move");
    }

    // Start is called before the first frame update
    
}
