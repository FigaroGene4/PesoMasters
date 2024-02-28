using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2GameSceneManager : MonoBehaviour
{
    public void HomeBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void NextBtnStage1()
    {
        SceneManager.LoadScene("GamesceneLvl2Stage2");
    }
    public void NextBtnStage2()
    {
        SceneManager.LoadScene("GamesceneLvl2Stage3");
    }
    public void NextBtnStage3()
    {
        SceneManager.LoadScene("GamesceneLvl3Stage1");
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

}
