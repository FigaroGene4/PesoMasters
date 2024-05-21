using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardViewer : MonoBehaviour
{
    public List<Sprite> cardSprites; // Assign these in the Inspector
    public Image cardImage; // Assign the CardImage UI element
    public Button nextButton;
    public Button previousButton;

    private int currentIndex;

    void Start()
    {
        if (cardSprites.Count > 0)
        {
            UpdateCardImage();
            nextButton.onClick.AddListener(ShowNextCard);
            previousButton.onClick.AddListener(ShowPreviousCard);
            previousButton.interactable = false; // Initially, there's no previous card
        }
        else
        {
            Debug.LogWarning("No card sprites assigned.");
        }
    }

    public void ClearCards()
    {
        cardSprites.Clear();
        currentIndex = 0;
        UpdateButtonInteractivity();
    }

    public void AddCard(string cardName)
    {
        // Construct the path to the sprite based on the provided card name
        // Note: the path should be relative to the Resources folder and should not include the file extension
        string path = $"CARD DESIGN (29.7 x 21 cm)/{cardName}";

        // Attempt to load the sprite from the Resources folder
        Sprite cardSpriteFolder = Resources.Load<Sprite>(path);

        // Check if the sprite was successfully loaded
        if (cardSpriteFolder != null)
        {
            // If the sprite is found, add it to the cardSprites list
            cardSprites.Add(cardSpriteFolder);

            // Update button interactivity (assumed to be implemented elsewhere in your code)
            UpdateButtonInteractivity();
        }
        else
        {
            // If the sprite is not found, log a warning to the console
            Debug.LogWarning($"Sprite for {cardName} not found at path: {path}");
        }
    }



    void ShowNextCard()
    {
        if (currentIndex < cardSprites.Count - 1)
        {
            currentIndex++;
            UpdateCardImage();
        }
        UpdateButtonInteractivity();
    }

    void ShowPreviousCard()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateCardImage();
        }
        UpdateButtonInteractivity();
    }

    void UpdateCardImage()
    {
        cardImage.sprite = cardSprites[currentIndex];
    }

    void UpdateButtonInteractivity()
    {
        nextButton.interactable = currentIndex < cardSprites.Count - 1;
        previousButton.interactable = currentIndex > 0;
    }
}
