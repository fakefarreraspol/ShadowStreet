using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnpoint;
    public GameObject[] enemy;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 5);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        int number = Random.Range(0, spawnpoint.Length);
        Instantiate(enemy[0], spawnpoint[number].position, Quaternion.identity);
    }
}
