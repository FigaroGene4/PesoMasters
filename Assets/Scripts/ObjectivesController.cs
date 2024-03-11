using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectivesController : MonoBehaviour
{
    [SerializeField] GameObject StartObjectivesPanel;
    [SerializeField] GameObject InGameObjectivesPanel;

    void Start()
    {
        StartObjectivesPanel.SetActive(true);
        InGameObjectivesPanel.SetActive(false);
    }
    public void CloseStartObjectives()
    {
        StartObjectivesPanel.SetActive(false);
    }
    public void CloseInGameObjectives()
    {
        InGameObjectivesPanel.SetActive(false);
    }
}
