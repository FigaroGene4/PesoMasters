using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    private Button button;
    private int clickCount;

    // Reference to a Text component to display the click count
    public Text clickCountText;

    void Start()
    {
        // Get the Button component attached to this GameObject
        button = GetComponent<Button>();

        // Add a listener to call the OnButtonClick method when the button is clicked
        //button.onClick.AddListener(OnButtonClick);

        // Initialize click count
        clickCount = 0;

        // Update the click count text initially
        UpdateClickCountText();
    }

    // Method to be called when the button is clicked
    void OnButtonClick()
    {
        // Increment the click count
        clickCount++;

        // Output a debug message with the updated click count
        Debug.Log("Button Clicked! Click Count: " + clickCount);

        // Update the click count text
        UpdateClickCountText();
    }

    // Update the click count text on the UI
    void UpdateClickCountText()
    {
        if (clickCountText != null)
        {
            clickCountText.text = "Click Count: " + clickCount.ToString();
        }
    }

   /* public void counter()
    {
     
            // Increment the click count
            clickCount++;

            // Output a debug message with the updated click count
            Debug.Log("Button Clicked! Click Count: " + clickCount);
        }*/
}
