using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1StageSceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void Lvl1Stage1()
    {
        SceneManager.LoadScene("GamesceneLvl1Stage1");
    }
    public void Lvl1Stage2()
    {
        SceneManager.LoadScene("GamesceneLvl1Stage2");
    }
    public void Lvl1Stage3()
    {
        SceneManager.LoadScene("GamesceneLvl1Stage3");
    }
}
