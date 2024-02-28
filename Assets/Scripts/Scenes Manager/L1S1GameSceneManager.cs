using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L1S1GameSceneManager : MonoBehaviour
{
    public void NextBtn()
    {
        SceneManager.LoadScene("Level1StagesMap");
    }
 
    public void ResetProgress()
    {
        // Reset the reached index to 1 (assuming the first level has index 0)
        PlayerPrefs.SetInt("ReachedIndex", 0);

        // Reset the unlocked level to 1
        PlayerPrefs.SetInt("Unlocked Level", 1);

        // Save changes
        PlayerPrefs.Save();
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
