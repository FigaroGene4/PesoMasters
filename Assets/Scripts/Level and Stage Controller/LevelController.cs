using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button[] levels;
    public int unlockedLevel;
    private int totalStages;
    private GameController gameController; // Reference to GameController

    private void Awake()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        UpdateLevelsInteractivity();
    }

    // Initialize the LevelController
    public void Init(GameController gameController, int totalStages)
    {
        this.gameController = gameController; // Store the reference to GameController
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        this.totalStages = totalStages;
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

    public void CheckUnlockNextLevel()
    {
        if (gameController == null)
        {
            Debug.LogError("GameController reference is null in LevelController.");
            return;
        }

        bool allStagesUnlocked = true;
        for (int i = 0; i < totalStages; i++)
        {
            if (!gameController.stageController.stages[i].interactable)
            {
                allStagesUnlocked = false;
                break;
            }
        }

        if (allStagesUnlocked)
        {
            gameController.UnlockNextLevel(); // Call GameController to unlock the next level
        }
    }

    // Method to unlock the next level (called by GameController)
    public void UnlockNextLevel()
    {
        unlockedLevel++;
        PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel);
        UpdateLevelsInteractivity();
    }
}
