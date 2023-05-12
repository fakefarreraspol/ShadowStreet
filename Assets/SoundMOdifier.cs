using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMOdifier : MonoBehaviour
{
    public AudioMixerSnapshot floorSnapshot;
    public AudioMixerSnapshot houseSnapshot;

    public float transitionTime = 0.25f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "House")
            floorSnapshot.TransitionTo(transitionTime);
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "House")
            houseSnapshot.TransitionTo(transitionTime);
    }
}