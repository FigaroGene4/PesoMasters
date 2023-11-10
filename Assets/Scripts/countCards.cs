using UnityEngine;
using UnityEngine.UI;

public class countCards : MonoBehaviour
{
    public Text CardsLeft; // Reference to your UI Text element
    private int clickCount = 30; // Start with 40 clicks test

    private void Start()
    {
        // Initialize the text to display the initial value (40)
        UpdateText();
      
        
    }

   

    private void OnMouseDown()
    {
      
            clickCount = Mathf.Max(0, clickCount - 1);

            // Update the text with the new value
            UpdateText();

        if (clickCount == 0)
        {
            // Display "Game Over" message in the Unity debug log
            Debug.Log("Game Over");
        }
    }
    

    private void UpdateText()
    {
        // Update the UI Text component with the current value of clickCount
        CardsLeft.text = clickCount.ToString();
    }



    
}
