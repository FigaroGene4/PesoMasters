using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5StageSceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMapLevel5");
    }
    public void Lvl5Stage1()
    {
        SceneManager.LoadScene("GamesceneLvl5Stage1");
    }
    public void Lvl5Stage2()
    {
        SceneManager.LoadScene("GamesceneLvl5Stage2");
    }
    public void Lvl5Stage3()
    {
        SceneManager.LoadScene("GamesceneLvl5Stage3");
    }
}
