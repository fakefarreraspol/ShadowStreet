using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSounds : MonoBehaviour
{
    public List<AudioClip> WalkSounds;
    public AudioSource audioSource;
    // Start is called before the first frame update
    public int pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        pos = (int)Mathf.Floor(Random.Range(0, WalkSounds.Count));
        audioSource.PlayOneShot(WalkSounds[pos]);
    }
}
