using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomepageSceneManager : MonoBehaviour
{
    public string GameMapLevel1;
    void OnMouseDown()
    {
        SceneManager.LoadScene(GameMapLevel1);
    }
}
