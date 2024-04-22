using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevel5SceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void MapCarnival()
    {
        SceneManager.LoadScene("Level5StagesMap");
    }
}
