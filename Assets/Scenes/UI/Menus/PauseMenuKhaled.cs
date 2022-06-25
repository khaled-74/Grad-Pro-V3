using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuKhaled : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (gameIsPaused)
            {
                Cursor.visible = false;
                Resume();

                if (optionMenuUI.activeSelf)
                {
                    optionMenuUI.SetActive(false);
                }
            }
            else
            {
                Cursor.visible = true;
                Pause();
            }
        }
    }

  public  void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the curser
        Cursor.visible = false;


       // dialogueUI.SetActive(true);
    }

    void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;  
        gameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

     //   dialogueUI?.SetActive(false);

    }
    public void LoadMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void BackTOMainMenu()
    {
        pauseMenuUI.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void BackToScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the curser
        Cursor.visible = false;
    }

}
