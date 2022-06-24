using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TMP_Text uiText;

    public int Duration;
    private int remainingDuration;

    private void Start()
    {
        Being(Duration);
    }
    private void Being(int Second) 
    {
        remainingDuration = Second;  
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer() 
    {
        while (remainingDuration >= 0) 
        {
            uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0,Duration,remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd() 
    {
        //End Time , if we want to do something 
        SceneManager.LoadScene(0);

    }
}

//float currentTime;
//public float startingTime = 10f;

//[SerializeField] Text countdownText;
//// Start is called before the first frame update
//void Start()
//{
//    currentTime = startingTime;
//}

//// Update is called once per frame
//void Update()
//{
//    currentTime -= 1
//    }