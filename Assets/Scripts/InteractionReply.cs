using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.SceneManagement;

public class InteractionReply : Interactable
{
    [SerializeField] private GameObject actor;
    int i = 1, j=1, t=1;
   // static int entry = 0;
    LevelLoader level;
    //HSlots check = new HSlots();
    //Scene currentScene = SceneManager.GetActiveScene();
    //string sceneName = currentScene.name;
    
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "ACT6" || SceneManager.GetActiveScene().name == "ACT8 opt")
        {
           // entry++;
            level = LevelLoader.FindObjectOfType<LevelLoader>();
        }
    }
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
            case "Hatshepsut's coffin":
                PixelCrushers.DialogueSystem.DialogueManager.BarkString("Interact with", gameObject.transform, actor.transform);
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
            case "Bust":
                PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Bust", actor.transform);
                break;
            case "rosetta":
                PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Rosetta", actor.transform);
                break;

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
                else if (SceneManager.GetSceneByName("ACT5.5").isLoaded && t == 1)
                {
                    PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Isis after act5", actor.transform, gameObject.transform);
                    t++;
                }
                else if (j > 1 || i > 1 || t>1)
                {
                    PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Tried Isis again", actor.transform, gameObject.transform);
                }
                break;
            case "horas":
                if (level.checkEntry())
                {
                    Debug.Log("entry was true");
                    PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Horus", actor.transform, gameObject.transform);
                   // Invoke("level.horusRoom", 180f);
                    level.horusRoom();
                    //SceneManager.LoadScene("Act7");
                }
                else /*(entry == 0)*/
                {
                    Debug.Log("entry is false");
                    PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Horusb4Puzzle", actor.transform, gameObject.transform);
                   // if()
                }
                   
                break;

            case "Hatshepsut's coffin":
                level.LoadNextLevel();
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
