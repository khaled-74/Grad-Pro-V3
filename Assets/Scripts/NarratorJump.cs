using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorJump : MonoBehaviour
{
    [SerializeField] private LevelLoader loader;
    [SerializeField] private AudioSource openAudioSource = default;//<-------
    [SerializeField] private AudioClip NarratorClip = default;
    [SerializeField] private float volume = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Narrator", 0.1f);
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            loader.LoadNextLevel();
    }

    void Narrator()
    {
        openAudioSource.PlayOneShot(NarratorClip, 0.7f);
    }
}
