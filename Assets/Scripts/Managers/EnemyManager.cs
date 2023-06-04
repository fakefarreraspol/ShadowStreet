using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnpoint;
    public GameObject[] enemy;

    public bool mode02 = false;
    void Start()
    {
        if (mode02) InvokeRepeating("SpawnEnemyRandom", 1, 5);
        else
        {
            for (int i = 0; i < spawnpoint.Length; i++)
            {
                SpawnEnemy(i);
            }
        }

    }

    // Update is called once per frame
    void SpawnEnemyRandom()
    {
        int number = Random.Range(0, spawnpoint.Length);
        Instantiate(enemy[0], spawnpoint[number].position, Quaternion.identity);
    }
    void SpawnEnemy(int numb)
    {
        Instantiate(enemy[0], spawnpoint[numb].position, Quaternion.identity);
    }
}
