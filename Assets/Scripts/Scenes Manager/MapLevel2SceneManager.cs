using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevel2SceneManager : MonoBehaviour
{

    public void BackBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void MapSchool()
    {
        SceneManager.LoadScene("Level2StagesMap");
    }

}