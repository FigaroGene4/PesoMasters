using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalStages = 3; // Total number of stages in your game

    // Function to be called when the game is completed
    public void GameCompleted()
    {
        int currentUnlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);

        // Increment the unlocked stage if it's not the last stage
        if (currentUnlockedStage < totalStages)
        {
            PlayerPrefs.SetInt("UnlockedStage", currentUnlockedStage + 1);
            PlayerPrefs.Save(); // Save the changes to PlayerPrefs
        }
    }
}
