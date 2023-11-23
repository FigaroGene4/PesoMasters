using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevel4SceneManager : MonoBehaviour
{
    public string GameMapLevel3;
    public string GameMapLevel5;
    public string Level4StagesMap;

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

            case "MapZoo":
                // Code for handling click on the third collider (go to another scene)
                GoToAnotherScene();
                break;
        }
    }

    void LoadPreviousScene()
    {
        SceneManager.LoadScene(GameMapLevel3);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(GameMapLevel5);
    }

    void GoToAnotherScene()
    {
        SceneManager.LoadScene(Level4StagesMap);
    }
}
