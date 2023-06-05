using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VrShooter : MonoBehaviour
{

    public InputActionProperty pinchAnimationAction;
    public Transform bulletStartPos;
    public GameObject bullet;
    AudioSource audioSourceee;
    private bool canShoot = false;
    public float shootForce;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceee = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();

        if (triggerValue > 0.90 && canShoot)
        {
            Shoot();
        }
        if (triggerValue < 0.10) canShoot = true;
    }


    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, bulletStartPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(bulletStartPos.forward * shootForce, ForceMode.Impulse);
        canShoot = false;
        audioSourceee.Play();
    }
}
