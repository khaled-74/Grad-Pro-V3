using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{
    [SerializeField] private List<PuzzlePiece> puzzlePiece;
    [SerializeField] private PuzzleSlot slot;
    [SerializeField] private LevelLoader loader;
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
            Debug.Log("Don't have key");

    }
}
