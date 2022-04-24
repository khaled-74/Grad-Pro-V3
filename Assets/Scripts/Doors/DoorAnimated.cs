using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DoorAnimated : MonoBehaviour
{
      [SerializeField] private List<Key.keyType> _keyType;
      [SerializeField] private KeyHolder _keyHolder;
      [SerializeField] private LevelLoader loader;//new 1
      [SerializeField] private GameObject actor;
    [SerializeField] private AudioSource pickUpAudioSource = default;
    [SerializeField] private AudioClip[] v1Clip = default;
    // private Animator animator;
    public bool isOpen;

    private void Awake()
    {
       // animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if (_keyHolder.ContainsKey(_keyType)) // or if the puzzle is right || 
        {
            //animator.SetBool("Open", true);
            //isOpen = true;
            pickUpAudioSource.PlayOneShot(v1Clip[Random.Range(0, v1Clip.Length - 1)]);
            loader.LoadNextLevel();//new 2
            Debug.Log("New Scene");
        }
        else
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Can't open", actor.transform);
            Debug.Log("Don't have key");
        }
        
    }

    //public void CloseDoor()
    //{
    //    animator.SetBool("Open", false);
    //    isOpen = false;
    //    Debug.Log("Door closed");
    //}
}
