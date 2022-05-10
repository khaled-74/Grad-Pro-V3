using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class InteractionReply : Interactable
{
    [SerializeField] private GameObject actor;
    int i = 1,j=1;
    //Scene currentScene = SceneManager.GetActiveScene();
    //string sceneName = currentScene.name;
    public override void OnFocus()
    {
        switch (gameObject.name)
        {
            case "Stand" :
                PixelCrushers.DialogueSystem.DialogueManager.BarkString("Interact", gameObject.transform, actor.transform);
                break;

            case "Stairs":
                PixelCrushers.DialogueSystem.DialogueManager.BarkString("Interact", gameObject.transform, actor.transform);
                break;

            case "ISIS":
                 PixelCrushers.DialogueSystem.DialogueManager.BarkString("Talk with", gameObject.transform, actor.transform);
                break;

            case "Ra":
                break;
            default:
                PixelCrushers.DialogueSystem.DialogueManager.BarkString("Press C to interact with", gameObject.transform, actor.transform);
                break;
        }
        
    }

    public override void OnInteract()
    {
        switch (gameObject.name)
        {

            case "Stand":
                PixelCrushers.DialogueSystem.DialogueManager.StartConversation("sees puzzle", actor.transform);
                break;

            case "Stairs":
                PixelCrushers.DialogueSystem.DialogueManager.StartConversation("RA's puzzle", actor.transform);
                break;
            case "ISIS":
                if (SceneManager.GetSceneByName("ACT3").isLoaded && i == 1)
                {
                    PixelCrushers.DialogueSystem.DialogueManager.StartConversation("1St meeting W ISIS", actor.transform, gameObject.transform);
                    i++;
                }
                else if(SceneManager.GetSceneByName("ACT4.5").isLoaded && j == 1)
                {
                    PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Isis 2nd conv", actor.transform, gameObject.transform);
                    j++;
                }
                else if (j > 1 || i > 1)
                {
                    PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Tried Isis again", actor.transform, gameObject.transform);
                }

                break;

        }
        //if (gameObject.name == "Stand")
        //{
           
        //}
        //if (gameObject.name == "Stairs")
        //{
           
        //}
        //PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Barks", actor.transform, null, Random.Range(4, 6));
    }

    public override void OnLoseFocus()
    {
       // throw new System.NotImplementedException();
    }

}
