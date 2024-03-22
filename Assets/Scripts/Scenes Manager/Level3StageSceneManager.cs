using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3StageSceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void Lvl3Stage1()
    {
        SceneManager.LoadScene("GamesceneLvl3Stage1");
    }
    public void Lvl3Stage2()
    {
        SceneManager.LoadScene("GamesceneLvl3Stage2");
    }
    public void Lvl3Stage3()
    {
        SceneManager.LoadScene("GamesceneLvl3Stage3");
    }
}
