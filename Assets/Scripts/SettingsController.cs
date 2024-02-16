using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject BGPanel;

    void Start()
    {
        BGPanel.SetActive(false);
    }
    public void Settings()
    {

        if (BGPanel != null)
        {
            BGPanel.SetActive(true);

            Debug.Log("Settings Pressed - After BGPanel.SetActive(true)");
            Time.timeScale = 0f;
            Debug.Log("Settings Pressed - After Time.timeScale = 0f");
        }
    }
    public void SaveProgress()
    {
        // Implement your save progress logic here
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClosePanel()
    {
        if (BGPanel != null)
        {
            BGPanel.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Panel reference is not set. Make sure to assign the panel GameObject in the inspector.");
        }
    }
}
