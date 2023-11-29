using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameSceneManager : MonoBehaviour
{
    public string CharacterPage;

    void Start()
    {
        // Attach the LoadNextScene method to the button's onClick event
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(LoadNextScene);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject.");
            button.onClick.AddListener(LoadNextScene);

        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(CharacterPage);
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
