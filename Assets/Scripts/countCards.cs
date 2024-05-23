using UnityEngine;
using UnityEngine.UI;

public class countCards : MonoBehaviour

{
    //public GameObject GameOverPanel, StageClearPanel;
    public Button yesButton, noButton;
    public Text CardsLeft; // Reference to your UI Text element
    public int clickCount = 20; // Start with 40 clicks test
    int clickCountz = 20;
    public CoinsBar coinbar;
    public SoundManager soundManager;

    private void Awake() {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
    }

    private void Start()
    {
        // Initialize the text to display the initial value (40)
        
        //UpdateText();
        if (clickCount != 0)
        {
            

        }

        else if (clickCount < 20)
        {
            UpdateText();

            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);
        }
    }
    public void OnMouseDown()
    {
        
        clickCount = Mathf.Max(0, clickCount - 1);

        clickCountz--;
        Debug.Log("Click" +clickCount);

        // Update the text with the new value
        UpdateText();

        if (clickCountz <= 0)
        {
            coinbar.CheckGoalReached();
            coinbar.GetMax();
            yesButton.interactable = false;
            noButton.interactable = false;        
            soundManager.StopMusic();
        }
                
        else
        {
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);
        }
    
    }
    
    private void UpdateText()
    {
        // Update the UI Text component with the current value of clickCount
        CardsLeft.text = clickCount.ToString();
        Debug.Log("Click" + clickCount);
    }    
}
