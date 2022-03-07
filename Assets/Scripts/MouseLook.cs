using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // a var to control the mouse speed

    public Transform playerBody; //ref to the player body

    ////
    //public float smoothedSpeed = 0.125f;
    //public Vector3 offset;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//so the cursor won't leave the screen
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse X/Y : pre programmed axis that changes based on our mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //input * mouseSensitivity * Time.deltaTime :to make sure that the rotation speed is the same regardless of the frame rate
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//to look up and down
        playerBody.Rotate(Vector3.up * mouseX);
    }

    //private void FixedUpdate()
    //{
    //    Vector3 desiredPosition = playerBody.position + offset;
    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothedSpeed);
    //    transform.position = smoothedPosition;
    //    transform.LookAt(playerBody);
    //}
}
