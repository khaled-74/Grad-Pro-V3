using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]public Animator transition;
    [SerializeField]public float transitionTime = 1f;
    // [SerializeField] public GameObject player = default;
    // public bool entry = false;
    //// Update is called once per frame
    //void Update()
    //{

    //}
    public static int entry = 0;
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "HorusPuzzle")
        { 
            entry = 1;
          //  checkEntry(entry);
        }
    }

    public bool checkEntry()
    {
        if (entry == 0)
            return false;
        else
            return true;
    }



    public void LoadNextLevel()
    {
        //if (SceneManager.GetActiveScene().name == "HorusPuzzle")
        //    entry = true;
        Debug.Log("loadlevel works");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //public void ForRa()
    //{
    //    SceneManager.LoadScene("Act 3");
    //    //player.transform.position = newPos;
    //}
    public void horusRoom()
    {
       // if(Input.GetKeyDown(KeyCode.X))
       
            StartCoroutine(LoadLevel(12,10f));
    }

    IEnumerator LoadLevel(int levelIndex , float delay = 0.0f)
    {
        Debug.Log("in coru");
        if (delay != 0)
            yield return new WaitForSeconds(delay);
        //Play animation
        transition.SetTrigger("Start");
        
        //wait
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("b4 loadscene");
        //Load scene
        SceneManager.LoadScene(levelIndex);
        Debug.Log("after loadscese");
    }
}
