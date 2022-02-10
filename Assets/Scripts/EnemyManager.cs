using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance = null;
    GameObject[] enemies;
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
            if (enemy.name.Contains(enemyName))
            {
                enemy.SetActive(true);
            }
        }
    }
}
