using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button[] levels;
    public int unlockedLevel;
    public int unlockedStage;

    private void Awake()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);

        for (int i = 0; i < levels.Length; i++)
        {
            // Determine if the current level button should be interactable
            if (i + 1 < unlockedLevel)
            {
                levels[i].interactable = true; // Unlock previous levels
            }
            else if (i + 1 == unlockedLevel)
            {
                // Unlock stages of the current level based on completed stages
                levels[i].interactable = i + 1 <= unlockedStage; // Level is interactable if its stage is completed
            }
            else
            {
                // Lock future levels
                levels[i].interactable = false;
            }
        }
    }
}
