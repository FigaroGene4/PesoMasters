using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4StageSceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void Lvl4Stage1()
    {
        SceneManager.LoadScene("GamesceneLvl4Stage1");
    }
    public void Lvl4Stage2()
    {
        SceneManager.LoadScene("GamesceneLvl4Stage2");
    }
    public void Lvl4Stage3()
    {
        SceneManager.LoadScene("GamesceneLvl4Stage3");
    }
}
