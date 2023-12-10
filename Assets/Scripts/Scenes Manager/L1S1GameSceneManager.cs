using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L1S1GameSceneManager : MonoBehaviour
{
    public void NextBtn()
    {
        SceneManager.LoadScene("Level1StagesMap");
    }
}
