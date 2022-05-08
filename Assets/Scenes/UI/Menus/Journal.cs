using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject journal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (gameIsPaused)
            {
             //   Cursor.visible = false;
                Resume();
            }
            else
            {
              //  Cursor.visible = true;
                Pause();
            }
        }
    }

    public void Resume()
    {

        journal.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        journal.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
