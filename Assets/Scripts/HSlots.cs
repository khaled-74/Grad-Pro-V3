using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HSlots : MonoBehaviour
{
    [SerializeField] List<GameObject> cubes;
    [SerializeField] private LevelLoader loader;

    //public static bool entry = false;
    public bool allsnaped(List<GameObject> cubes)
    {
        foreach (GameObject cube in cubes)
        {
           var snap = cube.GetComponent<newMechanic>();
            if (!snap.snapped)
                return false;
        }
        return true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (allsnaped(cubes))
            {
                //entry = true;
                SceneManager.LoadScene("ACT6");
                //loader.LoadNextLevel();
            }
        }
    }

}
