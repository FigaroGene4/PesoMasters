using UnityEngine;
using UnityEngine.UI;

public class countCards : MonoBehaviour

{
    public Button yesButton, noButton;
    public Text CardsLeft; // Reference to your UI Text element
    private int clickCount = 38; // Start with 40 clicks test
    int clickCountz = 38;

    private void Start()
    {
        // Initialize the text to display the initial value (40)

        UpdateText();
        if (clickCount != 0)
        {
            

        }

        if (clickCount < 38)
        {
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);
        }
    }

   

    public  void OnMouseDown()
    {
        clickCount = Mathf.Max(0, clickCount - 1);

        clickCountz--;
        Debug.Log("Click" +clickCount);

        // Update the text with the new value
        UpdateText();

        if (clickCountz < 0)
        {
            // Display "Game Over" message in the Unity debug log
            Debug.Log("Game Over");
            yesButton.interactable = false;
            noButton.interactable = false;
            
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
    }



    
}
