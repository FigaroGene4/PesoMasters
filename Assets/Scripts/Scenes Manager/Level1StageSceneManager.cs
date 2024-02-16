using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1StageSceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMapLevel1");
    }
    public void Lvl1Stage1()
    {
        SceneManager.LoadScene("GamesceneLvl1");
    }
    /*
    public void Lvl1Stage2()
    {
        SceneManager.LoadScene("GameMapLevel1");
    }
    public void Lvl1Stage3()
    {
        SceneManager.LoadScene("GameMapLevel1");
    }
    */
    
}
