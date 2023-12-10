using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomepageSceneManager : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("GameMapLevel1");
    } 
    public void HtpBtn()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
