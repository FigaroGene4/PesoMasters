using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button[] levels;
    public int unlockedLevel;

    private void Awake()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        UpdateLevelsInteractivity();
    }

    public void UpdateLevelsInteractivity()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            // Determine if the current level button should be interactable
            levels[i].interactable = i + 1 <= unlockedLevel;
        }
    }

    public void UnlockNextLevel()
    {
        unlockedLevel++;
        PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel);
        UpdateLevelsInteractivity();
    }
}