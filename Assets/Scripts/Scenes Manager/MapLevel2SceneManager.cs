using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevel2SceneManager : MonoBehaviour
{
    public string GameMapLevel1;
    public string GameMapLevel3;
    public string Level2StagesMap;

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
            case "MapPrevBtn":
                // Code for handling click on the first collider (load previous scene)
                LoadPreviousScene();
                break;

            case "MapNextBtn":
                // Code for handling click on the second collider (load next scene)
                LoadNextScene();
                break;

            case "MapSchool":
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
        SceneManager.LoadScene(GameMapLevel3);
    }

    void GoToAnotherScene()
    {
        SceneManager.LoadScene(Level2StagesMap);
    }
}