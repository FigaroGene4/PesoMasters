using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static void ResetProgress()
    {
        PlayerPrefs.DeleteAll(); // This will delete all stored player preferences
        Debug.Log("Player progress has been reset.");
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
    public void LogOut()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
