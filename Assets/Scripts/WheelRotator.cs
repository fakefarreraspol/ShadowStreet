using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotateSpeed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        transform.RotateAroundLocal(new Vector3(1,0,0), rotateSpeed * Time.deltaTime);
    }
}
