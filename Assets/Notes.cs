using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : Interactable
{
    [SerializeField] public GameObject note;
    
    private void Start()
    {
        note.SetActive(false);
    }
    public override void OnFocus()
    {
        // throw new System.NotImplementedException();
    }

    public override void OnInteract()
    {
        note.SetActive(true);
    }

    public override void OnLoseFocus()
    {
        //  throw new System.NotImplementedException();
    }


}
