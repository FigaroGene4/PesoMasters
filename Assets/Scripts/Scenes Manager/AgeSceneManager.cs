using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AgeSceneManager : MonoBehaviour
{

    public void LoadNextScene()
    {
        SceneManager.LoadScene("CharacterPage");
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene("EnterName");
    }
}
