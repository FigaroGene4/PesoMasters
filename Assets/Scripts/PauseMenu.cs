using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] 
    GameObject PausePanel;
  
    void Start()
    {
        PausePanel.SetActive(false);
    }

    public void Pause()
    {        
        if (PausePanel != null)
        {
            PausePanel.SetActive(true);
            Debug.Log("Pause Pressed - Before PausePanel.SetActive(true)");
            
            Debug.Log("Pause Pressed - After PausePanel.SetActive(true)");
            Time.timeScale = 0f;
            Debug.Log("Pause Pressed - After Time.timeScale = 0f");
        }
    }



    public void Resume()
    {
       
        if (PausePanel != null)
        {
           // PausePanelTest.gameObject.SetActive(false);
            PausePanel.SetActive(false);
            Time.timeScale = 1f; // Resume the game by setting time scale to 1
            Debug.Log("Resume Pressed");
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
    public void MainMenu()
    {
        if (!string.IsNullOrEmpty("MainMenu"))
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.LogError("Invalid scene name for MainMenu");
        }
    }

  
}
