using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] mummyType;

    public Transform miniPos;
    public Transform maxPos;

    public float startDelay = 2;
    public float spawnInterval = 1.5f;
 

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomMummy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomMummy()
    {
        //Random generatw mummy index and spawn position 

        float xpos = Random.Range(miniPos.position.x, maxPos.position.x);
        float zpos = Random.Range(miniPos.position.z, maxPos.position.z);
        float ypos = Random.Range(miniPos.position.y, maxPos.position.y);
        int mummyIndex = Random.Range(0, mummyType.Length);
        Vector3 spawnPos = new Vector3(xpos, ypos, zpos);
        Instantiate(mummyType[mummyIndex], spawnPos, mummyType[mummyIndex].transform.rotation);

    }

}



//Vector3 spawnPos = new Vector3(Random.Range())