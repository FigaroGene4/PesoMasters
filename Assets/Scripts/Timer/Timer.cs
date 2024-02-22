using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject GameOverPanel;

    private float startTime;
    private bool isTimerRunning;

    private void Start()
    {
        GameOverPanel.SetActive(false);
        isTimerRunning = false;
    }
    public void StartTimer()
    {
        if (!isTimerRunning)
        {
            startTime = Time.time;
            isTimerRunning = true;
        }
    }
    void Update()
    {
        if (isTimerRunning)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                timerText.color = Color.red;
                EndGame();
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }
    void EndGame()
    {
        GameOverPanel.SetActive(true);
    }
}
