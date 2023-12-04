using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameSceneManager : MonoBehaviour
{


    //Cinomment ko to kasi di nag pproceed sa next scene. Okay na cia
    /*void Start()
    {
        // Attach the LoadNextScene method to the button's onClick event
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(LoadNextScene);
        }
        else
        {
           // Debug.LogError("Button component not found on the GameObject.");
            button.onClick.AddListener(LoadNextScene);

        }
    }*/

    public void LoadNextScene()
    {
        SceneManager.LoadScene("AgeInput");
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
