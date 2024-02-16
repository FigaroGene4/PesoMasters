using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevel4SceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void MapZoo()
    {
        SceneManager.LoadScene("Level4StagesMap");
    }

}
