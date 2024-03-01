using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button[] levels;
    private int unlockedLevel;
    private int unlockedStage;

    private void Awake()
    {
        unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        unlockedStage = PlayerPrefs.GetInt("UnlockedStage", 1);

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].interactable = (i + 1) < unlockedLevel || (i + 1) == unlockedLevel && unlockedStage > 0;
        }
    }
}
