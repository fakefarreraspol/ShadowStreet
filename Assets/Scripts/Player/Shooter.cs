using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private Transform startingPoint;
    [SerializeField]
    private GameObject bullet;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, startingPoint.transform.position, bullet.transform.rotation);
        }
    }
}
