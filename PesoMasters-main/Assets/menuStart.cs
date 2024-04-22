using UnityEngine;
using UnityEngine.SceneManagement;

public class menuStart : MonoBehaviour
{
    public string targetSceneName; // Set this in the Inspector to the name of the target scene.

    public void LoadTargetScene()
    {
        targetSceneName = "GameScene";
        SceneManager.LoadScene(targetSceneName);
    }
}
