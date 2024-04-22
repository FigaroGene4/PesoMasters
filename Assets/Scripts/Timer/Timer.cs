using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public countCards cardCount;
    public CoinsBar coinBar;

    public float startTime;
    public bool isTimerRunning;
    public bool isPaused = false;

    private void Start()
    {
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
            else if (remainingTime <= 0)
            {
                remainingTime = 0;
                timerText.color = Color.red;
                StopTimer();
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            Goal();
        }
    }
    void Goal()
    {
        if (coinBar.starBar.current >= coinBar.neededStar && coinBar.current >= coinBar.neededCoin && coinBar.countCards.clickCount <= 0)
        {
            StopTimer();
            coinBar.GameComplete();
        }
        else if (coinBar.current <= 0 || coinBar.EnergyBar.current <= 0)
        {
            StopTimer();
            coinBar.CheckGameOver();
        }
    }
    public void PauseTimer()
    {
        isPaused = true;
    }
    public void ResumeTimer()
    {
        isPaused = false;
    }
    public void StopTimer()
    {
        isTimerRunning = false;
    }
}
