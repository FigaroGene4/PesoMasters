using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevel3SceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("GameMap");
    }
    public void MapBeach()
    {
        SceneManager.LoadScene("Level3StagesMap");
    }
}
