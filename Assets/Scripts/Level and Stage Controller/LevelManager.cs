using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons; // Array of level buttons
    public Button[] stageButtons; // Array of stage buttons

    private void Awake()
    {
        int stagesUnlocked = PlayerPrefs.GetInt("UnlockedStage", 1);
        int levelsUnlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Disable all stage buttons initially
        foreach (Button stageButton in stageButtons)
        {
            stageButton.interactable = false;
        }

        // Enable stage buttons based on the number of unlocked stages
        for (int i = 0; i < Mathf.Min(stagesUnlocked, stageButtons.Length); i++)
        {
            stageButtons[i].interactable = true;
        }

        // Disable all level buttons initially
        foreach (Button levelButton in levelButtons)
        {
            levelButton.interactable = false;
        }

        for (int i = 0; i < Mathf.Min(levelsUnlocked, levelButtons.Length); i++)
        {
            levelButtons[i].interactable = true;
        }

    }

    public void UnlockNextStage()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedStage", PlayerPrefs.GetInt("UnlockedStage", 1) + 1);
            PlayerPrefs.Save();
        }
    }
    public void UnlockNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex / 3; // Assuming each level has 3 stages

        if (currentLevelIndex >= PlayerPrefs.GetInt("ReachedLevel"))
        {
            PlayerPrefs.SetInt("ReachedLevel", currentLevelIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
    public bool AreAllStagesOfCurrentLevelCompleted()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex / 3; // Assuming each level has 3 stages
        int stagesCompleted = PlayerPrefs.GetInt("UnlockedStage", 1);

        return stagesCompleted >= (currentLevelIndex + 1) * 3;
    }
}
