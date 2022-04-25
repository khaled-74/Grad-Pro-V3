using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PixelCrushers.DialogueSystem;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField] private List<PuzzlePiece> puzzlePiece;
    [SerializeField] private PuzzleSlot slot;
    [SerializeField] private LevelLoader loader;
    [SerializeField] private AudioSource openAudioSource = default;//<-------
    [SerializeField] private AudioClip[] v1Clip = default;//<-------
    //[SerializeField] private GameObject actor;
    //private Animator animator;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if (slot.allSnapped(puzzlePiece)) // or if the puzzle is right || 
        {
            //animator.SetBool("Open", true);
            //isOpen = true;
            openAudioSource.PlayOneShot(v1Clip[Random.Range(0, v1Clip.Length - 1)]);//<-------
            loader.LoadNextLevel();
            Debug.Log("Door opened");
        }
        else
        {
           // PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Can't open", actor.transform);
            Debug.Log("Don't have key");
        }

    }
}
