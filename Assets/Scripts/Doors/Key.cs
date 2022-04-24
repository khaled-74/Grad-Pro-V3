//Script for the keys
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PixelCrushers.DialogueSystem;
//using PixelCrushers.DialogueSystem.
//using PixelCrushers.DialogueSystem.DialogueManager.BarkString;

public class Key : Interactable
{
    [SerializeField] private keyType _KeyType;
   // [SerializeField] private GameObject barker;
    public enum keyType { Gun, Journal, PuzzlePiece };

    public KeyHolder _KeyHolder;
    
    public keyType GetKeyType()
    {
        return _KeyType;
    }

    public override void OnInteract()
    {
        Debug.Log($"Added {_KeyType}");
        _KeyHolder.AddKey(_KeyType);
        Destroy(gameObject);
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
