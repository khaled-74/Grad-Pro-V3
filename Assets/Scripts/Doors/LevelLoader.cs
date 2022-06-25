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

    public void LoadNextLevel()
    {
        //if (SceneManager.GetActiveScene().name == "HorusPuzzle")
        //    entry = true;
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
       
            StartCoroutine(LoadLevel(10,90f));
    }

    IEnumerator LoadLevel(int levelIndex , float delay = 0.0f)
    {
        if (delay != 0)
            yield return new WaitForSeconds(delay);
        //Play animation
        transition.SetTrigger("Start");
        
        //wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
