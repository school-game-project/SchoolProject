using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public float totalSecondsPerGame;
    public float secondsLeft;
    public Text countdownText;

    public delegate void CountDownHandler(bool WonOrLost);
    public event CountDownHandler OnCountdownOver;

    private int minutes;
    private int seconds;


    private void Awake()
    {
        
        secondsLeft = totalSecondsPerGame;
    }


    public void StartCountDown()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        while(secondsLeft > 0)
        {
            yield return new WaitForSeconds(1.0f);
            minutes = (int)(secondsLeft / 60);
            seconds = (int)(secondsLeft % 60);

            countdownText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            secondsLeft -= 1;
        }

        // ToDo Detect when loose or won
        OnCountdownOver(true);
    }
	
}
