using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectivesController : MonoBehaviour
{
    [SerializeField] GameObject StartObjectivesPanel;
    [SerializeField] GameObject InGameObjectivesPanel;
    [SerializeField] private GameObject TutorialPanel;

    void Start()
    {
        StartObjectivesPanel.SetActive(true);
        InGameObjectivesPanel.SetActive(false);
    }
    public void CloseStartObjectives()
    {
        StartObjectivesPanel.SetActive(false);
        TutorialPanel.SetActive(true);
    }
    public void CloseInGameObjectives()
    {
        InGameObjectivesPanel.SetActive(false);
    }
    public void OpenInGameObjectives()
    {
        InGameObjectivesPanel.SetActive(true);
    }
}
