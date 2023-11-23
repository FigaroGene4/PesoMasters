using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLevel1SceneManager : MonoBehaviour
{
    public string GameMapLevel2;
    public string Level1StagesMap;
    public string Homepage;

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

            case "MapPlayground":
                // Code for handling click on the third collider (go to another scene)
                GoToAnotherScene();
                break;
        }
    }

    void LoadPreviousScene()
    {
        SceneManager.LoadScene(Homepage);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(GameMapLevel2);
    }

    void GoToAnotherScene()
    {
        SceneManager.LoadScene(Level1StagesMap);
    }
}
