using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGameSceneManager : MonoBehaviour
{
    public void HomeBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void Lvl1NextStage()
    {
        SceneManager.LoadScene("Level1StagesMap");
    }
    public void Lvl2NextStage()
    {
        SceneManager.LoadScene("Level2StagesMap");
    }
    public void Lvl3NextStage()
    {
        SceneManager.LoadScene("Level3StagesMap");
    }
    public void Lvl4NextStage()
    {
        SceneManager.LoadScene("Level4StagesMap");
    }
    public void Lvl5NextStage()
    {
        SceneManager.LoadScene("Level5StagesMap");
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
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
}
