using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterSceneManager : MonoBehaviour
{
    public string Homepage;

    void OnMouseDown()
    {
        ///SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(Homepage);
    }
}
