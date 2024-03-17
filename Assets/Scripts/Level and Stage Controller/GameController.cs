using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public LevelController levelController;
    public StageController stageController;

    private int nextStageToUnlock; // Variable to store the stage number to unlock next

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Find LevelController and StageController in the scene
        levelController = FindObjectOfType<LevelController>();
        stageController = FindObjectOfType<StageController>();
    }

    // Method to unlock a stage
    public void UnlockStage(int stageNumber)
    {
        stageController.UnlockStage(stageNumber);
        levelController.UpdateLevelsInteractivity(); // Update levels' interactivity
    }

    // Method to set the next stage to unlock
    public void SetNextStageToUnlock(int stageNumber)
    {
        nextStageToUnlock = stageNumber;
    }

    // Method to unlock the next stage
    public void UnlockNextStage()
    {
        UnlockStage(nextStageToUnlock);
    }
}