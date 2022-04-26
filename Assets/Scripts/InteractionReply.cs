using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class InteractionReply : Interactable
{
    [SerializeField] private GameObject actor;

    public override void OnFocus()
    {
        PixelCrushers.DialogueSystem.DialogueManager.BarkString("Press C to interact with", gameObject.transform, actor.transform);
    }

    public override void OnInteract()
    {
        PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Barks", actor.transform, null, Random.Range(4, 6));
    }

    public override void OnLoseFocus()
    {
       // throw new System.NotImplementedException();
    }

}
