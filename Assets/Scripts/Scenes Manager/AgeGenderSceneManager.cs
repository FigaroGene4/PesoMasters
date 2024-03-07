using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AgeGenderSceneManager : MonoBehaviour
{

    public void AgeLoadNextScene()
    {
        SceneManager.LoadScene("GenderSelection");
    }
    public void AgePreviousScene()
    {
        SceneManager.LoadScene("EnterName");
    }
    public void GenderLoadNextScene()
    {
        SceneManager.LoadScene("CharacterPage");
    }
    public void GenderPreviousScene()
    {
        SceneManager.LoadScene("AgeInput");
    }
}
