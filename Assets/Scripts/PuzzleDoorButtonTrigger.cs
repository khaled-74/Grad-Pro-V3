using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PuzzleDoorButtonTrigger : Interactable
{
    [SerializeField] private PuzzleDoor puzzleDoor;
   

    public override void OnFocus()
    {
        
        Debug.Log("Open door?");
    }

    public override void OnInteract()
    {

        puzzleDoor.OpenDoor();

    }

    public override void OnLoseFocus()
    {
        Debug.Log("Lose focus from door");
    }
}
