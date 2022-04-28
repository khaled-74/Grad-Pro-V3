using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class InteractionReply : Interactable
{
    [SerializeField] private GameObject actor;

    public override void OnFocus()
    {
        if(gameObject.name == "Stand")
        {
            PixelCrushers.DialogueSystem.DialogueManager.BarkString("Interact", gameObject.transform, actor.transform);
        }
        PixelCrushers.DialogueSystem.DialogueManager.BarkString("Press C to interact with", gameObject.transform, actor.transform);
    }

    public override void OnInteract()
    {
        if (gameObject.name == "Stand")
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("sees puzzle", actor.transform);
        }
        PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Barks", actor.transform, null, Random.Range(4, 6));
    }

    public override void OnLoseFocus()
    {
       // throw new System.NotImplementedException();
    }

}
