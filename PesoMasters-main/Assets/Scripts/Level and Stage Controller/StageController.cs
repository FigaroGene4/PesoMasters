using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public Button[] stages;
    public int unlockedStage;

    private void Awake()
    {
        unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);
        UpdateStagesInteractivity();
    }

    public void UnlockStage(int stageNumber)
    {
        // Unlock the stage
        unlockedStage = Mathf.Max(unlockedStage, stageNumber);
        PlayerPrefs.SetInt("UnlockedStage", unlockedStage);
        UpdateStagesInteractivity();
    }

    private void UpdateStagesInteractivity()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            // Determine if the current stage button should be interactable
            stages[i].interactable = i + 1 <= unlockedStage;
        }
    }

    public void AutoUnlockNextStage()
    {
        int nextStageNumber = unlockedStage + 1;
        // Unlock the next stage automatically
        UnlockStage(nextStageNumber);
    }
}
