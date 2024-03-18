using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L1GameSceneManager : MonoBehaviour
{
    public void HomeBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void NextBtnStage1()
    {
        SceneManager.LoadScene("GamesceneLvl1Stage2");
    }
    public void NextBtnStage2()
    {
        SceneManager.LoadScene("GamesceneLvl1Stage3");
    }
    public void NextBtnStage3()
    {
        SceneManager.LoadScene("GamesceneLvl2Stage1");
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
