using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorTriggerButton : Interactable
{
    [SerializeField] private DoorAnimated door;
    [SerializeField] public GameObject actor;
    int i = 0;
    public override void OnFocus()
    {
        i++;
        if (SceneManager.GetSceneByName("ACT5").isLoaded && i==1)
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Finished Maze", actor.transform);
        }
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
