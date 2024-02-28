using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMapSceneManager : MonoBehaviour
{
    public void BackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PlaygroundBtn()
    {
        SceneManager.LoadScene("GameMapLevel1");
    }
    public void SchoolBtn()
    {
        SceneManager.LoadScene("GameMapLevel2");
    }
    public void BeachBtn()
    {
        SceneManager.LoadScene("GameMapLevel3");
    }
    public void ZooBtn()
    {
        SceneManager.LoadScene("GameMapLevel4");
    }
    public void ParkBtn()
    {
        SceneManager.LoadScene("GameMapLevel5");
    }
    public void StoreBtn()
    {
        //SceneManager.LoadScene("GameMapLevel5");
    }

    public static void ResetProgress()
    {
        PlayerPrefs.DeleteAll(); // This will delete all stored player preferences
        Debug.Log("Player progress has been reset.");
    }

}
