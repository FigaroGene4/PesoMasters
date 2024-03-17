using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3StageSceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    /*
    public void Lvl3Stage1()
    {
        SceneManager.LoadScene("GamesceneLvl2");
    }
    public void Lvl3Stage2()
    {
        SceneManager.LoadScene("GameMapLevel1");
    }
    public void Lvl3Stage3()
    {
        SceneManager.LoadScene("GameMapLevel1");
    }
    */
}
