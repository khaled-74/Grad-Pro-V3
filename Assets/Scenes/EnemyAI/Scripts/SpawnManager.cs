using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] zombieType;
    public GameObject[] zombieSpawn;
    public int zombieIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            Instantiate(zombieType[zombieIndex], new Vector3(0,0,0),zombieType[zombieIndex].transform.rotation);
        }
    }
}
