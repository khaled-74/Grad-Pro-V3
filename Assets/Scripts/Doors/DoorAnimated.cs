using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour
{
      [SerializeField] private List<Key.keyType> _keyType;
      [SerializeField] private KeyHolder _keyHolder;

    private Animator animator;
    public bool isOpen;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        if (_keyHolder.ContainsKey(_keyType)) // or if the puzzle is right || 
        {
            animator.SetBool("Open", true);
            isOpen = true;
            Debug.Log("Door opened");
        }
        else
            Debug.Log("Don't have key");
        
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
        isOpen = false;
        Debug.Log("Door closed");
    }
}
