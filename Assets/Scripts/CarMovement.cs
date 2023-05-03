using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Car settings")]
    private float speed = 0;
    [SerializeField]
    private float minSpeed = 0;
    [SerializeField]
    private float maxSpeed = 0;

    [Header("Wheels")]
    [SerializeField]
    private GameObject[] wheels;  
    
    [SerializeField]
    private float rotateSpeed;
    //public GameObject car;
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        RotateWheels();

        if(transform.position.y < -10)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void RotateWheels()
    {
        for (int i=0; i < wheels.Length; i++)
        {
            //wheels[i].transform.Rotate(new Vector3(1,0,0) * rotateSpeed * Time.deltaTime);
            wheels[i].transform.Rotate(new Vector3(10,0,0) * Time.deltaTime);
        }
    }
}
