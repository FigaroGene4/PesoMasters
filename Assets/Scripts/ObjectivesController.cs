using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectivesController : MonoBehaviour
{
    [SerializeField]
    GameObject ObjectivesPanel;

    void Start()
    {
        ObjectivesPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        ObjectivesPanel.SetActive(false);
    }
}
