/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knapsack : MonoBehaviour
{
    public class YourClass
    {
        // Assuming knapsackDictionary is accessible from this class
        Dictionary<string, Cards> knapsackDictionary = new Dictionary<string, Cards>();

        // Boolean variable to determine the button choice
        bool isYesButtonClicked = false;

        public void OnButtonClick()
        {
            // Set isYesButtonClicked based on your button logic
            // For example, you might set it to true if the "yes" button is clicked
            // and false if the "no" button is clicked.

            // Example:
            // isYesButtonClicked = true; // Set to true if "yes" button is clicked

            // Call getGold based on the button choice
            if (isYesButtonClicked)
            {
                getGold();
            }
            else
            {
                string nameOfCard = drawCards.currCardName;
                if (cardDictionary.TryGetValue(nameOfCard, out Cards card))
                {
                    if (card != null)
                    {
                        // Only add the card to the knapsackDictionary without other actions
                        AddToKnapsackDictionary(nameOfCard, card);
                    }
                    else
                    {
                        Debug.Log(nameOfCard + " or " + nameOfCard + ".gold is null");
                    }
                }
                else
                {
                    Debug.Log("Card not found: " + nameOfCard);
                }
            }
        }

        public void getGold()
        {
            string nameOfCard = drawCards.currCardName;

            if (cardDictionary.TryGetValue(nameOfCard, out Cards card))
            {
                if (card != null)
                {
                    current += card.gold;
                    Debug.Log("Gold:" + card.gold);

                    // Add the card to the knapsackDictionary using the new function
                    AddToKnapsackDictionary(nameOfCard, card);
                }
                else
                {
                    Debug.Log(nameOfCard + " or " + nameOfCard + ".gold is null");
                }
            }
            else
            {
                Debug.Log("Card not found: " + nameOfCard);
            }

            UpdateGoldText();
        }

        // New function to add a card to the knapsackDictionary
        public void AddToKnapsackDictionary(string cardName, Cards card)
        {
            if (!knapsackDictionary.ContainsKey(cardName))
            {
                knapsackDictionary.Add(cardName, card);
                Debug.Log("Added to knapsackDictionary: " + cardName);
            }
        }

        // Your other methods...
    }



}
*/