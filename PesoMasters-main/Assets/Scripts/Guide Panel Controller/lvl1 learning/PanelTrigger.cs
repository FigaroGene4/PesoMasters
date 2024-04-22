using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTrigger : MonoBehaviour
{
    public PanelController panelController;
    public float panelDuration = 2f;

    [SerializeField] GameObject Click;
    void Start()
    {
        Click.SetActive(true);
        panelController.ShowPanelForDuration(panelDuration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
