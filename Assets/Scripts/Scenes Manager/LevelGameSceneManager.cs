using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGameSceneManager : MonoBehaviour
{
    public GameObject reviewPanel;
    public DrawCards drawCards;
    public CardViewer cardViewer;

    public void HomeBtn()
    {
        SceneManager.LoadScene("GameMap");
    }

    public void Lvl1NextStage()
    {
        SceneManager.LoadScene("Level1StagesMap");
    }

    public void Lvl2NextStage()
    {
        SceneManager.LoadScene("Level2StagesMap");
    }

    public void Lvl3NextStage()
    {
        SceneManager.LoadScene("Level3StagesMap");
    }

    public void Lvl4NextStage()
    {
        SceneManager.LoadScene("Level4StagesMap");
    }

    public void Lvl5NextStage()
    {
        SceneManager.LoadScene("Level5StagesMap");
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ResetProgress()
    {
        PlayerPrefs.SetInt("ReachedIndex", 0);
        PlayerPrefs.SetInt("Unlocked Level", 1);
        PlayerPrefs.Save();
    }

    public void HelpBtn()
    {
        if (reviewPanel != null)
        {
            reviewPanel.SetActive(!reviewPanel.activeSelf);
            if (reviewPanel.activeSelf)
            {
                if (drawCards != null)
                {
                    List<GameObject> drawnCards = drawCards.drawnCards;
                    Debug.Log("Drawn Cards:");

                    // Clear existing cards in the card viewer
                    cardViewer.ClearCards();

                    // Display the names of drawn cards and load corresponding images
                    foreach (GameObject card in drawnCards)
                    {
                        if (card != null)
                        {
                            string cardName = card.name.Replace("(Clone)", "");
                            Debug.Log(cardName);

                            cardViewer.AddCard(cardName);

                        }
                        else
                        {
                            Debug.LogWarning("A drawn card is null.");
                        }
                    }
                    if (drawnCards.Count != 20)
                    {
                        drawnCards.RemoveAt(drawnCards.Count - 1);
                    }

                    // List to store card details
                    List<(string name, int coins, int energy, int stars)> cardDetails = new List<(string name, int coins, int energy, int stars)>();

                    // Populate card details
                    foreach (GameObject card in drawnCards)
                    {
                        if (card != null)
                        {
                            string cardName = card.name.Replace("(Clone)", "");
                            int coins = 0, energy = 0, stars = 0;

                            switch (cardName)
                            {
                                case "BONUS-1": coins = 15; energy = 0; break;
                                case "BONUS-2": coins = 10; energy = 0; break;
                                case "BONUS-3": coins = 15; energy = 0; break;
                                case "BONUS-4": coins = 5; energy = 0; break;
                                case "BONUS-5": coins = 10; energy = 0; break;
                                case "BONUS-6": coins = 10; energy = 0; break;
                                case "BONUS-7": coins = 0; energy = 5; break;
                                case "BONUS-8": coins = 0; energy = 8; break;
                                case "BONUS-9": coins = 0; energy = 8; break;
                                case "BONUS-10": coins = 0; energy = 10; break;

                                case "EXPENSE-1": coins = -15; energy = 3; break;
                                case "EXPENSE-2": coins = -15; energy = 3; break;
                                case "EXPENSE-3": coins = -10; energy = 2; break;
                                case "EXPENSE-4": coins = -10; energy = 2; break;
                                case "EXPENSE-5": coins = -5; energy = 4; break;
                                case "EXPENSE-6": coins = -5; energy = 2; break;
                                case "EXPENSE-7": coins = -8; energy = 3; break;
                                case "EXPENSE-8": coins = -10; energy = 2; break;
                                case "EXPENSE-9": coins = -20; energy = 5; break;
                                case "EXPENSE-10": coins = -10; energy = 3; break;

                                case "CHALLENGE-2-lvl1-stage1": stars = 1; break;
                                case "CHALLENGE-lvl1 (2)": stars = 1; break;
                                case "CHALLENGE-lvl1 (3)": stars = 1; break;
                                case "CHALLENGE-lvl1 (4)": stars = 1; break;
                                case "CHALLENGE-lvl1 (5)": stars = 1; break;
                                case "CHALLENGE-lvl1 (6)": stars = 1; break;
                                case "CHALLENGE-lvl1": stars = 1; break;
                                case "CHALLENGE-lvl2 (2)": stars = 1; break;
                                case "CHALLENGE-lvl2 (3)": stars = 1; break;
                                case "CHALLENGE-lvl2 (4)": stars = 1; break;

                                case "Income": coins = 15; energy = -3; break;
                                case "Income (2)": coins = 10; energy = -3; break;
                                case "Income (3)": coins = 15; energy = -2; break;
                                case "Income (4)": coins = 10; energy = -2; break;
                                case "Income (5)": coins = 15; energy = -3; break;
                                case "Income (6)": coins = 10; energy = -2; break;
                                case "Income (7)": coins = 20; energy = -3; break;
                                case "Income (8)": coins = 10; energy = -3; break;
                                case "Income (9)": coins = 8; energy = -3; break;
                                case "Income (10)": coins = 15; energy = -4; break;
                            }

                            cardDetails.Add((cardName, coins, energy, stars));
                        }
                    }


                    // Greedy algorithm to select cards based on the order of drawing
                    int totalCoins = 15; // Initial coins
                    int totalEnergy = 15; // Initial energy
                    int totalStars = 0;
                    List<string> selectedCards = new List<string>();

                    Debug.Log("Selected Cards for Optimal Result:");

                    var sortedCards = cardDetails.OrderByDescending(card => card.coins).ToList();

                    foreach (var card in sortedCards)
                    {
                        // Check if selecting the card is beneficial and feasible
                        bool isBeneficial = card.coins > 0 || card.energy > 0 || card.stars > 0;
                        bool isFeasible = totalEnergy + card.energy > 0 && totalCoins + card.coins > 0;

                        // New condition: accept the card if its coins, energy, or stars don't affect totals when added
                        bool noChangeCondition = (totalCoins + card.coins == totalCoins) && (totalEnergy + card.energy == totalEnergy) && (totalStars + card.stars == totalStars);

                        // Ensure energy does not drop to zero or below
                        bool maintainsEnergy = totalEnergy + card.energy > 0;

                        if ((isBeneficial && isFeasible && maintainsEnergy) || noChangeCondition)
                        {
                            // Update total values
                            totalCoins += card.coins;
                            totalEnergy += card.energy;
                            totalStars += card.stars;

                            // Add card to the list of selected cards
                            selectedCards.Add(card.name);

                            // Log the card details
                            Debug.Log($"Suggested Card: {card.name}, Coins: {card.coins}, Energy: {card.energy}, Stars: {card.stars}");
                        }
                    }

                    // Log the final results
                    Debug.Log($"Total Coins: {totalCoins}, Total Energy: {totalEnergy}, Total Stars: {totalStars}");
                    cardViewer.SetSelectedCards(selectedCards);

                }

            }
            }
        }
    }
