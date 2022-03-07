using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour
{
    public Transform spot;

    private void OnMouseDown()
    {
        transform.parent = GameObject.Find("Spot").transform;
        transform.position = spot.position;
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
   }

    private void OnMouseUp()
    {
        transform.parent = null;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().useGravity=true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
