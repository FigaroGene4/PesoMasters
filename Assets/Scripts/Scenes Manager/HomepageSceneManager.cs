using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomepageSceneManager : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("GameMap");
    } 
    public void HtpBtn()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
