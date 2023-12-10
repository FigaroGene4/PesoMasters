using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TutorialController : MonoBehaviour
{
   private VideoPlayer videoPlayer;

    void Start()
    {
        // Get the VideoPlayer component attached to this GameObject
        videoPlayer = GetComponent<VideoPlayer>();

        // Subscribe to the videoPlayer.loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;

        // Play the video when the scene starts
        videoPlayer.Play();
    }

    // Called when the video reaches the end
    void OnVideoEnd(VideoPlayer vp)
    {
        // Unsubscribe from the event to avoid multiple calls
        videoPlayer.loopPointReached -= OnVideoEnd;

       LoadPreviousScene();
    }

    void LoadPreviousScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
