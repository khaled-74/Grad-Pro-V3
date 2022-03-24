using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable
{

    //private Color startColor;
   // [SerializeField] private DoorAnimated door;//
    public override void OnFocus()
    {
        Debug.Log("LOOKING AT " + gameObject.name);
    }

    public override void OnInteract()
    {
        Debug.Log("INTERACTED WITH " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        Debug.Log("STOPPED LOOKING AT " + gameObject.name);
    }
}
