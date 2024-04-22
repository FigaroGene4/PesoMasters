using System.Collections;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel;

    public void ShowPanelForDuration(float duration)
    {
        StartCoroutine(ShowPanel(duration));
    }

    private IEnumerator ShowPanel(float duration)
    {
        panel.SetActive(true);

        yield return new WaitForSeconds(duration);

        panel.SetActive(false);
    }
}
