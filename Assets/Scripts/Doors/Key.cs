//Script for the keys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
//using PixelCrushers.DialogueSystem.
//using PixelCrushers.DialogueSystem.DialogueManager.BarkString;

public class Key : Interactable
{
    [SerializeField] private keyType _KeyType;
    [SerializeField] private GameObject actor;
    public enum keyType { Gun, Journal, PuzzlePiece };

    public KeyHolder _KeyHolder;
    [SerializeField] private AudioSource pickUpAudioSource = default;
    [SerializeField] private AudioClip[] v1Clip = default;

    public keyType GetKeyType()
    {
        return _KeyType;
    }

    public override void OnInteract()
    {
        Debug.Log($"Added {_KeyType}");
        _KeyHolder.AddKey(_KeyType);
        pickUpAudioSource.PlayOneShot(v1Clip[Random.Range(0, v1Clip.Length - 1)]);
        Destroy(gameObject);
        if (_KeyType == keyType.Gun)
        {
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Abt gun", actor.transform);
        }
        else if (_KeyType == keyType.Journal){
            PixelCrushers.DialogueSystem.DialogueManager.StartConversation("Abt journal", actor.transform);
        }
    }

    public override void OnFocus()
    {
        Debug.Log($"Get the {_KeyType}?");
       // PixelCrushers.DialogueSystem.DialogueManager.BarkString("Press E to collect.", barker.transform);
       // Debug.Log($"Get the {_KeyType}?");
    }

    public override void OnLoseFocus()
    {
        Debug.Log($"Not looking at {_KeyType}.");
    }
}
