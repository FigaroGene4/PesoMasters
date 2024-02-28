using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public Button[] stages;
    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("Unlocked Level", 1);

        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].interactable = (i + 1) <= unlockedLevel;
        }
    }
}