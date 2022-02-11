using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance = null;
    GameObject[] enemies;

    public enum State
    {
        Search,
        Move,
        Attack,
        Death
    }

    public GameObject zombie1;
    public GameObject zombie2;
    public GameObject zombie3;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveEnemy(string enemyName)
    {
        foreach (GameObject enemy in enemies)
        {
            try
            {

                if (enemy.name.Contains(enemyName))
                {
                    enemy.SetActive(true);
                }
            } 
            catch (MissingReferenceException e)
            {
                continue;
            }
        }
    }

    public void SetEnemyState(int zombieIndex, State state)
    {
        switch(zombieIndex)
        {
            case 1: zombie1.GetComponent<Enemy_Zombie>().state = (Enemy_Zombie.State)state; break;
            case 2: zombie2.GetComponent<Enemy_Zombie>().state = (Enemy_Zombie.State)state; break;
            case 3: zombie3.GetComponent<Enemy_Zombie>().state = (Enemy_Zombie.State)state; break;
            default: break;
        }
    }
}
