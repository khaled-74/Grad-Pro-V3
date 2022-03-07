using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpClip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { audioSource.PlayOneShot(jumpClip); }

    }

}
