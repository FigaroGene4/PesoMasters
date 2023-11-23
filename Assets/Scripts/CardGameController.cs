using UnityEngine;
using UnityEngine.UI;

public class CardGameController : MonoBehaviour
{
    public Button yesbtn;
    public Button nobtn;

    private int savings = 0;
    private int energy = 0;
    private int currentCardIndex = 0;

    private Card[] cards;

    void Start()
    {
        // Initialize your cards with scenarios and corresponding savings/energy changes.
        InitializeCards();

        // Set up button click events.
        yesbtn.onClick.AddListener(OnYesButtonClick);
        nobtn.onClick.AddListener(OnNoButtonClick);

        // Display the first card.
        ShowCurrentCard();
    }

    void InitializeCards()
    {
        // Create an array of cards with scenarios and their corresponding savings/energy changes.
        cards = new Card[]
        {
            new Card("Scenario 1: Buy a coffee", -2, 1),
            new Card("Scenario 2: Save money on groceries", 3, -1),
            // Add more scenarios as needed...
        };
    }

    void ShowCurrentCard()
    {
        // Display the current card's scenario.
        //cardText.text = cards[currentCardIndex].scenario;
    }

    void OnYesButtonClick()
    {
        // Apply greedy algorithm: Choose the option that maximizes savings or minimizes energy consumption.
        if (cards[currentCardIndex].savingsChange > cards[currentCardIndex].energyChange)
        {
            savings += cards[currentCardIndex].savingsChange;
        }
        else
        {
            energy += cards[currentCardIndex].energyChange;
        }

        // Check if the player's answer is correct and display the appropriate pop-up.
        CheckAnswerAndShowPopUp();

        // Move to the next card.
        MoveToNextCard();
    }

    void OnNoButtonClick()
    {
        // Apply greedy algorithm: Choose the option that maximizes savings or minimizes energy consumption.
        if (cards[currentCardIndex].savingsChange > cards[currentCardIndex].energyChange)
        {
            energy += cards[currentCardIndex].energyChange;
        }
        else
        {
            savings += cards[currentCardIndex].savingsChange;
        }

        // Check if the player's answer is correct and display the appropriate pop-up.
        CheckAnswerAndShowPopUp();

        // Move to the next card.
        MoveToNextCard();
    }

    void CheckAnswerAndShowPopUp()
    {
        // Check if the player's answer is correct based on the greedy algorithm.
        bool isCorrect = savings + energy == 0;

        // Display a pop-up with the correct answer if the player's answer is wrong.
        if (!isCorrect)
        {
            string correctAnswerPopUp = $"Incorrect!\nCorrect Answer: Savings = {savings}, Energy = {energy}";
            // Show the pop-up (implement your pop-up display logic here).
            Debug.Log(correctAnswerPopUp);
        }
    }

    void MoveToNextCard()
    {
        // Move to the next card.
        currentCardIndex++;

        // Check if all cards have been played and reset the game if needed.
        if (currentCardIndex >= cards.Length)
        {
            ResetGame();
        }
        else
        {
            // Display the next card.
            ShowCurrentCard();
        }
    }

    void ResetGame()
    {
        // Reset game variables and start over.
        savings = 0;
        energy = 0;
        currentCardIndex = 0;

        // Display the first card.
        ShowCurrentCard();
    }
}

public class Card
{
    public string scenario;
    public int savingsChange;
    public int energyChange;

    public Card(string scenario, int savingsChange, int energyChange)
    {
        this.scenario = scenario;
        this.savingsChange = savingsChange;
        this.energyChange = energyChange;
    }
}
