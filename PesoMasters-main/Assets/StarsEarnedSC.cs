using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class StarsEarnedSC : MonoBehaviour
{

    public Image[] stars;
    public Sprite yellowStarSprite;
    public Sprite grayStarSprite;
    public CoinsBar coinsBar;
    public StarBar starBar;

    public void DisplayStarsEarned(int filledStars)
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i < filledStars)
            {
                // Set yellow colored star sprite
                stars[i].sprite = yellowStarSprite;
            }
            else
            {
                // Set gray colored star sprite
                stars[i].sprite = grayStarSprite;
            }
        }
    }
}