using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public LevelController levelController;
    public StageController stageController;

    private int nextStageToUnlock; // Variable to store the stage number to unlock next
    public static GameController instance;

    private void Awake()
    {
        Debug.Log("GameController Awake method called.");
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Find LevelController and StageController in the scene
        levelController = FindObjectOfType<LevelController>();
        stageController = FindObjectOfType<StageController>();

        if (levelController == null)
        {
            Debug.LogError("LevelController not found in the scene.");
        }
        if (stageController == null)
        {
            Debug.LogError("StageController not found in the scene.");
        }

        levelController.Init(this, stageController.stages.Length);
    }



    // Method to unlock a stage
    public void UnlockStage(int stageNumber)
    {
        stageController.UnlockStage(stageNumber);
        levelController.UpdateLevelsInteractivity(); // Update levels' interactivity
        levelController.CheckUnlockNextLevel(); // Check if all stages are unlocked to unlock the next level
    }

    // Method to unlock the next stage
    public void UnlockNextStage()
    {
        UnlockStage(nextStageToUnlock);
    }

    // Method to set the next stage to unlock
    public void SetNextStageToUnlock(int stageNumber)
    {
        nextStageToUnlock = stageNumber;
    }

    // Method to unlock the next level
    public void UnlockNextLevel()
    {
        levelController.UnlockNextLevel();
    }
}
