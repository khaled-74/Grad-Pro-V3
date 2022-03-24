using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : Interactable
{
    [SerializeField] private DoorAnimated door;
    public override void OnFocus()
    {
        Debug.Log("Open door?");
    }

    public override void OnInteract()
    {
        if (!door.isOpen)
        { 
            door.OpenDoor();
        }
        //else
        //{
        //    door.CloseDoor();
        //}
    }

    public override void OnLoseFocus()
    {
        Debug.Log("Lose focus from door");
    }
}
