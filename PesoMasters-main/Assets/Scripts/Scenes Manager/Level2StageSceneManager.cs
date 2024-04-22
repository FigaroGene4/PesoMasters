using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2StageSceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void Lvl2Stage1()
    {
        SceneManager.LoadScene("GamesceneLvl2Stage1");
    }
    public void Lvl2Stage2()
    {
        SceneManager.LoadScene("GamesceneLvl2Stage2");
    }
    public void Lvl2Stage3()
    {
        SceneManager.LoadScene("GamesceneLvl2Stage3");
    }
}
