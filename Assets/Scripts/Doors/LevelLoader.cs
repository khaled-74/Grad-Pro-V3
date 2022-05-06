using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]public Animator transition;
    [SerializeField]public float transitionTime = 1f;
   // [SerializeField] public GameObject player = default;

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    public void LoadNextLevel()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ForRa()
    {
        SceneManager.LoadScene("Act 3");
        //player.transform.position = newPos;
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}
