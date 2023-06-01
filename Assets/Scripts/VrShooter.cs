using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VrShooter : MonoBehaviour
{

    public InputActionProperty pinchAnimationAction;
    public Transform bulletStartPos;
    public GameObject bullet;
    
    private bool canShoot = false;
    public float shootForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();

        if (triggerValue > 0.90 && canShoot)
        {
            GameObject newBullet = Instantiate(bullet, bulletStartPos.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * shootForce, ForceMode.Impulse);
            canShoot = false;
        }
        if(triggerValue < 0.10) canShoot = true;
    }
}
