using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaregetSelector : MonoBehaviour
{
    public Camera camera;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        { //from camera to mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Target>() != null)
                {
                    //Vector3 distanceToTarget = hitInfo.point - transform.position;
                    //Vector3 forceDirection = distanceToTarget.normalized;
                    // Debug.Log("cube selected");
                 
                }
                if (hitInfo.collider.gameObject.tag == "wall")
                { Debug.Log("wall selected"); }
            }
        }
    }
}
