using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSlots : MonoBehaviour
{
    [SerializeField] List<GameObject> cubes;
    [SerializeField] private LevelLoader loader;

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
                loader.LoadNextLevel();
            }
        }
    }

}
