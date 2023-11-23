using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2StageSceneManager : MonoBehaviour
{
    public string Homepage;
    public string GameMapLevel2;
    public string Gamescene;

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

            case "Lvl2SchoolbusLocked":
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
        SceneManager.LoadScene(GameMapLevel2);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(Gamescene);
    }

    void GoToAnotherScene()
    {
        SceneManager.LoadScene(Homepage);
    }
}
