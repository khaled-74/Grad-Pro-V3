using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [Header("Functional Options")]
    [SerializeField] private bool canInteract = true;

    [Header("Controls")]
    [SerializeField] private KeyCode interactionKey = KeyCode.E;

    [Header("Interaction Parameters")]
    [SerializeField] public Vector3 interactionRayPoint = default;
    [SerializeField] private float interactionDistance = default;
    [SerializeField] private LayerMask interactableLayer = 8;
    private Interactable currentInteractable;

    private Camera playerCamera;
   
    private void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();

       
    }
   
    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            HandleInteractionCheck();//constantly raycasts looking 4 interactable obj
            HandleInteractionInput();//the interaction func
        }
    }

    private void HandleInteractionCheck()
    {
        RaycastHit hitInfo;
        Ray ray = playerCamera.ViewportPointToRay(interactionRayPoint);

        if (Physics.Raycast(ray, out hitInfo, interactionDistance))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.black);

            if (hitInfo.collider.gameObject.layer == 8 && (currentInteractable == null || hitInfo.collider.gameObject.GetInstanceID() != currentInteractable.GetInstanceID()))
            {
                hitInfo.collider.TryGetComponent(out currentInteractable);

                if (currentInteractable)
                    currentInteractable.OnFocus();
                Debug.DrawLine(ray.origin, hitInfo.point, Color.black);
            }
        }
        else if (currentInteractable)
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.black);
            currentInteractable.OnLoseFocus();
            currentInteractable = null;
            Debug.DrawLine(ray.origin, hitInfo.point, Color.black);
        }
    }
    private void HandleInteractionInput()
    {
        Ray ray = playerCamera.ViewportPointToRay(interactionRayPoint);
        RaycastHit hitInfo;
        //try if condition with key tag and then diff key for anything key related
        
        if (Input.GetKeyDown(interactionKey) && currentInteractable != null && Physics.Raycast(ray, out hitInfo, interactionDistance, interactableLayer))
        {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.black);
                currentInteractable.OnInteract();//the interaction
                Debug.DrawLine(ray.origin, hitInfo.point, Color.black ); 
        }
    }
}
