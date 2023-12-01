using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSceneManager : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene("EnterName");
    }
}
