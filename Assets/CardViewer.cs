using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardViewer : MonoBehaviour
{
    public List<Sprite> cardSprites; // Assign these in the Inspector
    public Image cardImage; // Assign the CardImage UI element
    public Button nextButton;
    public Button previousButton;

    private int currentIndex = 0;

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
        Sprite cardSprite = Resources.Load<Sprite>($"Sprites/CARD DESIGN (29.7 x 21 cm)/{cardName}");
        if (cardSprite != null)
        {
            cardSprites.Add(cardSprite);
            UpdateButtonInteractivity();
        }
        else
        {
            Debug.LogWarning($"Sprite for {cardName} not found.");
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
