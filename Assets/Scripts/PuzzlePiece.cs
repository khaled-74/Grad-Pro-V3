using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    [SerializeField] private float grapDistance;
    [SerializeField] private float snapDistance;
    [SerializeField] private Vector3 ogPoint;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject slot;
    [SerializeField] private AudioSource pickUpAudioSource = default;//<-------
    [SerializeField] private AudioClip[] v1Clip = default;//<-------

    private Vector3 mOffset;
    private Vector3 snapOffset = new Vector3(0f, 0f, 0.4f);
   // private Vector3 centerWrongOffset = new Vector3(0f, 0f, 1.5f);
    private float mZCoord;
    private bool okayToDrag = false;
    public bool snapped = false;
   // public string destinationArea = "Drop Area";


    private void OnMouseDown()
    {
        float dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (dist <= grapDistance)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            // Store offset = gameObject world pos - MouseLook world pos;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
            transform.GetComponent<Collider>().enabled = false;
            okayToDrag = true;
            pickUpAudioSource.PlayOneShot(v1Clip[Random.Range(0, v1Clip.Length - 1)]);//<-------
            Debug.Log("Could drag");
        }
        else
            Debug.Log("too far");
    }

    private Vector3 GetMouseWorldPos()
    {
        //pixel coordinate(x,y)
        Vector3 mousePoint = Input.mousePosition;
        //z coordinate of gameobject on screen
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseUp()
    {
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = GetMouseWorldPos() - Camera.main.transform.position;
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, rayDirection, out hitInfo))
        {
            Debug.DrawLine(rayOrigin, hitInfo.point, Color.black);

            float dist = Vector3.Distance(hitInfo.transform.position, gameObject.transform.position);

            //if (hitInfo.transform.tag == destinationArea && dist <= snapDistance )
            if (hitInfo.transform.name == slot.transform.name)
            {
                Debug.Log("it read the tag");
                transform.position = hitInfo.transform.position - snapOffset; //- centerWrongOffset;
                pickUpAudioSource.PlayOneShot(v1Clip[Random.Range(0, v1Clip.Length - 1)]);//<-------
                Debug.Log("It snapped");
                snapped = true;

            }
            else
            {
                transform.position = ogPoint;
                pickUpAudioSource.PlayOneShot(v1Clip[Random.Range(0, v1Clip.Length - 1)]);//<-------
                Debug.Log("Returned to og point");
            }
        }
        transform.GetComponent<Collider>().enabled = true;
        okayToDrag = false;
    }
    private void OnMouseDrag()
    {
        if (okayToDrag == true && snapped == false)
        {
            transform.position = GetMouseWorldPos() + mOffset;
            Debug.Log("Being dragged");
        }
    }

}
