using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button[] level;
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("Unlocked Level", 1);

        for (int i = 0; i < level.Length; i++)
        {
            level[i].interactable = (i + 1) <= unlockedLevel;
        }
    }
}