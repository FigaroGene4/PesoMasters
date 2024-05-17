using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewPanel : MonoBehaviour
{
    public GameObject cardDisplay; // Image or other UI element to display the card
    private List<GameObject> drawnCards;
    private int currentCardIndex = 0;
    public GameObject CardExp1, CardExp2, CardExp3, CardExp4, CardExp5, CardExp6, CardExp7, CardExp8, CardExp9, CardExp10;
    public GameObject CardInc1, CardInc2, CardInc3, CardInc4, CardInc5, CardInc6, CardInc7, CardInc8, CardInc9, CardInc10;
    public GameObject CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10;
    public GameObject CardChallenge1, CardChallenge2, CardChallenge3, CardChallenge4, CardChallenge5, CardChallenge6, CardChallenge7, CardChallenge8;

    public void Initialize(List<GameObject> cards)
    {
        drawnCards = cards;
        if (drawnCards.Count > 0)
        {
            DisplayCard(drawnCards[currentCardIndex]);
        }
        UpdateButtons();
    }

    public void LeftBtn()
    {
        if (currentCardIndex > 0)
        {
            currentCardIndex--;
            DisplayCard(drawnCards[currentCardIndex]);
        }
        UpdateButtons();
    }

    public void RightBtn()
    {
        if (currentCardIndex < drawnCards.Count - 1)
        {
            currentCardIndex++;
            DisplayCard(drawnCards[currentCardIndex]);
        }
        UpdateButtons();
    }

    private void DisplayCard(GameObject card)
    {
        // Display the card on the UI, e.g., set the sprite of an Image component
        // Example for Image component:
        Image imageComponent = cardDisplay.GetComponent<Image>();
        if (imageComponent != null)
        {
            SpriteRenderer cardSprite = card.GetComponent<SpriteRenderer>();
            if (cardSprite != null)
            {
                imageComponent.sprite = cardSprite.sprite;
            }
        }
    }

    private void UpdateButtons()
    {
        leftButton.interactable = currentCardIndex > 0;
        rightButton.interactable = currentCardIndex < drawnCards.Count - 1;
    }
}
