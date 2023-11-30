using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomepageSceneManager : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("GameMapLevel1");
    }
}
