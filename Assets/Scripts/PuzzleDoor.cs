using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PixelCrushers.DialogueSystem;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField] private List<PuzzlePiece> puzzlePiece;
    [SerializeField] private PuzzleSlot slot;
    [SerializeField] private LevelLoader loader;
    //[SerializeField] private GameObject actor;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if (slot.allSnapped(puzzlePiece)) // or if the puzzle is right || 
        {
            //animator.SetBool("Open", true);
            //isOpen = true;
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
