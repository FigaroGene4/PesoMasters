using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class TutorialController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public Button skipButton; // Assign your skip button in the inspector

    void Start()
    {
        // Get the VideoPlayer component attached to this GameObject
        videoPlayer = GetComponent<VideoPlayer>();

        // Subscribe to the videoPlayer.loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;

        // Play the video when the scene starts
        videoPlayer.Play();

        // Subscribe the skip button's onClick event to the SkipVideo method
        skipButton.onClick.AddListener(SkipVideo);
    }

    // Called when the video reaches the end
    void OnVideoEnd(VideoPlayer vp)
    {
        // Unsubscribe from the event to avoid multiple calls
        videoPlayer.loopPointReached -= OnVideoEnd;

        // Load the main menu scene
        LoadMainMenuScene();
    }

    public void SkipVideo()
    {
        // Stop the video and load the main menu scene
        videoPlayer.Stop();
        LoadMainMenuScene();
    }

    // Method to load the main menu scene
    void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
