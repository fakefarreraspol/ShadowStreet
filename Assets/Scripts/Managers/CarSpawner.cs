using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawners;
    public GameObject[] cars;
    
    private int randomSpawn;
    
    void Start()
    {
        InvokeRepeating("SpawnCar", 1, 10);       
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    void SpawnCar()
    {
        randomSpawn = Random.Range(0, spawners.Length);

        if(randomSpawn == 1)
        {
            Instantiate (cars[0], spawners[randomSpawn].transform.position, Quaternion.Euler(0,180,0));
        }
        else Instantiate (cars[0], spawners[randomSpawn].transform.position, Quaternion.identity);
        // Instantiate (cars[0], spawners[randomSpawn].transform.position, Quaternion.Euler(0,180,0));
    }
}
