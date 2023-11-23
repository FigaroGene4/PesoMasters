using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomepageSceneManager : MonoBehaviour
{
    public string GameScene;
    void OnMouseDown()
    {
        SceneManager.LoadScene(GameScene);
    }
}
