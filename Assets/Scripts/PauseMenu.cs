using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;

    void Start()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
        }
    }

    public void Pause()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game by setting time scale to 0
        }
    }


    public void Resume()
    {
        if (PausePanel != null)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1f; // Resume the game by setting time scale to 1
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Make sure time scale is set to 1 when restarting
    }
      public void Leave()
    {
        if (!string.IsNullOrEmpty("Level1StagesMap"))
        {
            SceneManager.LoadScene("Level1StagesMap");
        }
        else
        {
            Debug.LogError("Invalid scene name for Level1StagesMap");
        }
    }
    public void Home()
    {
        if (!string.IsNullOrEmpty("Homepage"))
        {
            SceneManager.LoadScene("Homepage");
        }
        else
        {
            Debug.LogError("Invalid scene name for Homepage");
        }
    }

  
}
