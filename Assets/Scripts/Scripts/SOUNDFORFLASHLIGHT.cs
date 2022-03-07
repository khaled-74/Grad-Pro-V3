using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOUNDFORFLASHLIGHT : MonoBehaviour
    
{
    public AudioSource[] soundFX;
    void Update()
    {
        if (Input.GetButtonDown(" F "))
        {
            soundFX[0].Play();
        }
        
    }
    
}
