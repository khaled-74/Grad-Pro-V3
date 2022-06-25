using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;
public class TutorialManager : MonoBehaviour
{
    [SerializeField] public GameObject panel;
    [SerializeField] public GameObject player;
    [SerializeField] public float dis;
    [SerializeField] public GameObject[] popUps;
    private int popUpIndex;
    float distance;
    void Update()
    {


        for (int i = 0; i < popUps.Length; i++)
        {
             
            if (panel.activeInHierarchy || distance >= dis)
                popUps[i].SetActive(false);
            else /*if (distance <= 7.0f)*/
                popUps[i].SetActive(i == popUpIndex);
            distance = Vector3.Distance(popUps[popUpIndex].transform.position, player.transform.position);
        }
        
        if (SceneManager.GetSceneByName("ACT1").isLoaded  )
        {
            if (popUpIndex == 0)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
                    popUpIndex++;
            }
            else if (popUpIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.C))
                    popUpIndex++;
            }
            else if (popUpIndex == 2)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    popUpIndex++;
                    Debug.Log("finished");
                }
            }
        }
        if (SceneManager.GetSceneByName("ACT2").isLoaded)
        {
            if (popUpIndex == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                    popUpIndex++;
            }
            else if (popUpIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    popUpIndex++;
            }
            else if (popUpIndex == 2)
            {
                if (Input.GetKeyDown(KeyCode.F))
                    popUpIndex++;
            }
            else if (popUpIndex == 3)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl))
                    popUpIndex++;
            }
            else if (popUpIndex == 4)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                    popUpIndex++;
            }
            else if (popUpIndex == 5)
            {
                if (Input.GetKeyDown(KeyCode.C))
                    popUpIndex++;
                Debug.Log("finished");
            }
        }
        if (SceneManager.GetSceneByName("ACT4_Ra_puzzle").isLoaded)
        {
            if (popUpIndex == 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                    popUpIndex++;
                Debug.Log("Finshed");
            }
        }
    }
}
