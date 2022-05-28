using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject journal;
    public MouseLook mouseLook;
    public GameObject gunContainer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (gameIsPaused)
            {
             //   Cursor.visible = false;
             JournalEnable();

            }
            else
            {
              //  Cursor.visible = true;
              JournalDisable();
            }
        }
    }

    public void JournalEnable()
    {
        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.None;
        //to hide the curser
        Cursor.visible = true;

        journal.SetActive(true);
       // Time.timeScale = 0f;
        gameIsPaused = false;

        //Mouse look refrance script
        mouseLook.enabled = false;

        //Gun container refrance
       gunContainer.SetActive(false);

    }

    void JournalDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        journal.SetActive(false);
      //  Time.timeScale = 1f;
        gameIsPaused = true;

        mouseLook.enabled = true;
        gunContainer.SetActive(true);



    }
}
