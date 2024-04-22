using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl345ObjectivesController : MonoBehaviour
{
    [SerializeField] GameObject StartObjectivesPanel;
    [SerializeField] GameObject InGameObjectivesPanel;
    public Timer timer;

    void Start()
    {
        StartObjectivesPanel.SetActive(true);
        InGameObjectivesPanel.SetActive(false);
        Debug.Log("start");
    }

    public void CloseStartObjectives()
    {
        StartObjectivesPanel.SetActive(false);
        timer.StartTimer();
        Debug.Log("timer start");
    }
    public void OpenInGameObjectives()
    {
        InGameObjectivesPanel.SetActive(true);
        timer.PauseTimer();
        Debug.Log("timer paused");
    }
    public void CloseInGameObjectives()
    {
        InGameObjectivesPanel.SetActive(false);
        timer.ResumeTimer();
        Debug.Log("timer resume");
    }
}
