using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1StageSceneManager : MonoBehaviour
{
    public string Homepage;
    public string GameMapLevel1;
    public string GamesceneLvl1;

    void OnMouseDown()
    {
        HandleClick();
    }

    void HandleClick()
    {
        // Implement different logic based on the GameObject's name or tag
        string Buttons = gameObject.name;
        switch (Buttons)
        {
            case "backbtn":
                // Code for handling click on the first collider (load previous scene)
                LoadPreviousScene();
                break;

            case "SeesawStage1":
                // Code for handling click on the second collider (load next scene)
                LoadNextScene();
                break;

            case "homebtn":
                // Code for handling click on the third collider (go to another scene)
                GoToAnotherScene();
                break;
        }
    }

    void LoadPreviousScene()
    {
        SceneManager.LoadScene(GameMapLevel1);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(GamesceneLvl1);
    }

    void GoToAnotherScene()
    {
        SceneManager.LoadScene(Homepage);
    }
}
