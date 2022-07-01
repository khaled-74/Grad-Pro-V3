using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HSlots : MonoBehaviour
{
    [SerializeField] List<GameObject> cubes;
    [SerializeField] private LevelLoader loader;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //public static bool entry = false;
    public bool allsnaped(List<GameObject> cubes)
    {
        foreach (GameObject cube in cubes)
        {
           var snap = cube.GetComponent<newMechanic>();
            if (!snap.snapped)
                return false;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        return true;
    }

    private void Update()
    {
        if (allsnaped(cubes))
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                //entry = true;
                
                SceneManager.LoadScene("ACT6");
                //loader.LoadNextLevel();
            }
        }
    }

}
