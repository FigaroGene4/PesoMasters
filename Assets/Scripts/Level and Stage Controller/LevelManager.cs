using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // Array of level buttons
    public Button[] stageButtons; // Array of stage buttons
    private int[] levelsUnlocked; // Array to keep track of unlocked levels
    private int[] stagesUnlocked; // Array to keep track of unlocked stages

    void Start()
    {
        levelsUnlocked = new int[levelButtons.Length];
        stagesUnlocked = new int[stageButtons.Length];

        // Initialize level and stage unlocking status
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelsUnlocked[i] = PlayerPrefs.GetInt("Level" + (i + 1), 0);
            UpdateLevelButton(i);
        }

        for (int i = 0; i < stageButtons.Length; i++)
        {
            stagesUnlocked[i] = PlayerPrefs.GetInt("Stage" + (i + 1), 0);
            UpdateStageButton(i);
        }
    }

    // Unlock a level
    public void UnlockLevel(int levelIndex)
    {
        levelsUnlocked[levelIndex] = 1;
        PlayerPrefs.SetInt("Level" + (levelIndex + 1), 1);
        UpdateLevelButton(levelIndex);
    }

    // Unlock a stage
    public void UnlockStage(int stageIndex)
    {
        stagesUnlocked[stageIndex] = 1;
        PlayerPrefs.SetInt("Stage" + (stageIndex + 1), 1);
        UpdateStageButton(stageIndex);
    }

    // Update level button UI based on unlocking status
    private void UpdateLevelButton(int levelIndex)
    {
        levelButtons[levelIndex].interactable = levelsUnlocked[levelIndex] == 1;
    }

    // Update stage button UI based on unlocking status
    private void UpdateStageButton(int stageIndex)
    {
        stageButtons[stageIndex].interactable = stagesUnlocked[stageIndex] == 1;
    }
}
