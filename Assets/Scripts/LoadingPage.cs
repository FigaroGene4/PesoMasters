using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Image LoadingBarFill;

    void Start()
    {
        // Start loading the next scene in the background
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");

        while (!asyncLoad.isDone)
        {
            // Update the fill amount of the loading fill image based on the loading progress
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            LoadingBarFill.fillAmount = progress;

            yield return null;
        }

        // Ensure that the loading fill is fully visible before transitioning to the next scene
        LoadingBarFill.fillAmount = 1.0f;

        // Play the "Loading" sound effect
        SoundManager.Instance.PlaySFX("Loading");

        // Wait for a short delay to let the loading fill be visible to the user
        yield return new WaitForSeconds(0.5f);

        // Transition to the next scene
        SceneManager.LoadScene("SampleScene");
    }
}
