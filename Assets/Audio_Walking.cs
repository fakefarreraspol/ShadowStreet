using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Audio_Walking : MonoBehaviour
{
    public AudioClip[] footstepsOnFloor;
    public AudioClip[] footstepsOnHouse;

    public string material;

    void PlayFootstepSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = Random.Range(0.9f, 1.0f);
        audioSource.pitch = Random.Range(0.9f, 1.1f);

        switch (material)
        {
            case "Floor":
                if (footstepsOnFloor.Length > 0)
                    audioSource.PlayOneShot(footstepsOnFloor[Random.Range(0, footstepsOnFloor.Length)]);
                break;

            case "House":
                if (footstepsOnHouse.Length > 0)
                    audioSource.PlayOneShot(footstepsOnHouse[Random.Range(0, footstepsOnHouse.Length)]);
                break;

            default:
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Floor":
            case "House":
                material = collision.gameObject.tag;
                break;

            default:
                break;
        }
    }
}
