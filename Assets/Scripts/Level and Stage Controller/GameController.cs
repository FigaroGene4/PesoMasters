using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public LevelController levelController; // Reference to the LevelController script

    public void UnlockNextStage()
    {
        if (levelController.unlockedLevel <= levelController.levels.Length && levelController.unlockedStage < 3)
        {
            levelController.unlockedStage++;
            if (levelController.unlockedStage > 3)
            {
                levelController.unlockedStage = 1;
                levelController.unlockedLevel++;
                Debug.Log("Unlocking next stage...");
            }
            PlayerPrefs.SetInt("UnlockedStage", levelController.unlockedStage);
            PlayerPrefs.SetInt("UnlockedLevel", levelController.unlockedLevel);
            PlayerPrefs.Save();
            Debug.Log("Unlocking next level...");
        }
        else
        {
            Debug.Log("All stages are already unlocked or maximum stages reached.");
        }
    }

}
