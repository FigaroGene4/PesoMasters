using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class CoinsBar : MonoBehaviour
{
    public DrawCards drawCards;
    public int maximum;
    public int current;
    public Image mask;
    public Cards CardExp1, CardExp2, CardExp3, CardExp4, CardExp5, CardExp6, CardExp7, CardExp8, CardExp9, CardExp10,
            CardInc1, CardInc2, CardInc3, CardInc4, CardInc5, CardInc6, CardInc7, CardInc8, CardInc9, CardInc10,
            CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10,
            CardChallenge1, CardChallenge2, CardChallenge3, CardChallenge4, CardChallenge5, CardChallenge6, CardChallenge7, CardChallenge8;
    //public Cards Income1, Income2, Income3, Income4;
    public Dictionary<string, Cards> cardDictionary; // Add this dictionary to store Cards instances by name
    private int maxGold;

    // Start is called before the first frame update
    void Start()
    {
        InitializeCards();
    }

    void InitializeCards()
    {
        // Initialize the dictionary with your Cards instances
        cardDictionary = new Dictionary<string, Cards>
        {
            {"Expense1", CardExp1},
            {"Expense2", CardExp2},
            {"Expense3", CardExp3},
            {"Expense4", CardExp4},
            {"Expense5", CardExp5},
            {"Expense6", CardExp6},
            {"Expense7", CardExp7},
            {"Expense8", CardExp8},
            {"Expense9", CardExp9},
            {"Expense10", CardExp10},
            {"Income1", CardInc1},
            {"Income2", CardInc2},
            {"Income3", CardInc3},
            {"Income4", CardInc4},
            {"Income5", CardInc5},
            {"Income6", CardInc6},
            {"Income7", CardInc7},
            {"Income8", CardInc8},
            {"Income9", CardInc9},
            {"Income10", CardInc10},
            {"Bonus1", CardBonus1},
            {"Bonus2", CardBonus2},
            {"Bonus3", CardBonus3},
            {"Bonus4", CardBonus4},
            {"Bonus5", CardBonus5},
            {"Bonus6", CardBonus6},
            {"Bonus7", CardBonus7},
            {"Bonus8", CardBonus8},
            {"Bonus9", CardBonus9},
            {"Bonus10", CardBonus10},
            {"Challenge1", CardChallenge1},
            {"Challenge2", CardChallenge2},
            {"Challenge3", CardChallenge3},
            {"Challenge4", CardChallenge4},
            {"Challenge5", CardChallenge5},
            {"Challenge6", CardChallenge6},
            {"Challenge7", CardChallenge7},
            {"Challenge8", CardChallenge8},
        };
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
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

        if (drawCards != null && drawCards.currCardName != null)
        {
            Debug.Log("Cur" + drawCards.currCardName);
        }
        else
        {
            Debug.Log("drawCards or drawCards.currentCard is null");
        }
    }

    
    public (int, int) KnapSack(int W, Dictionary<string, Cards> items)
    {
        int n = items.Count;
        
        var K = new (int, int)[n + 1, W + 1];

        var itemList = items.Values.ToList();

        for (int i = 0; i <= n; i++)
        {
            for (int w = 0; w <= W; w++)
            {
                if (i == 0 || w == 0)
                {
                    K[i, w] = (0, 0);
                }
                else if (itemList[i - 1].weight <= w)
                {
                    var prev_val = K[i - 1, w - itemList[i - 1].weight];
                    var new_val = (itemList[i - 1].gold + prev_val.Item1, itemList[i - 1].energy + prev_val.Item2);
                    K[i, w] = Max(new_val, K[i - 1, w]);
                }
                else
                {
                    K[i, w] = K[i - 1, w];
                }
            }
        }

        var result = K[n, W];
        Debug.Log("Max gold: " + result.Item1 + ", Max energy: " + result.Item2);  // Add this line to log the max value

        return result;
    }

    private (int, int) Max((int, int) a, (int, int) b)
    {
        if (a.Item1 > b.Item1)
        {
            return a;
        }
        else if (a.Item1 < b.Item1)
        {
            return b;
        }
        else
        {
            return a.Item2 > b.Item2 ? a : b;
        }
    }


    public void GetMax()
    {
        int W = 38;  // Set the maximum weight
        var result = KnapSack(W, cardDictionary);  // Call the KnapSack method

        // Now result contains the maximum gold and energy
        Debug.Log("Max gold: " + result.Item1 + ", Max energy: " + result.Item2);
    }


    /*public void getGold()
    {
        string nameOfDrawnCard = drawCards.currCardName;

        // Create a list to store the available cards
        List<Cards> availableCards = new List<Cards>(cardDictionary.Values);

        // Filter cards based on the drawn card's name
        List<Cards> matchingCards = availableCards.FindAll(card => card.name == nameOfDrawnCard);

        // Sort the matching cards by gold value in descending order
        matchingCards.Sort((card1, card2) => card2.gold.CompareTo(card1.gold));

        // Iterate through the sorted matching cards and greedily select the ones with the highest gold
        foreach (Cards card in matchingCards)
        {
            if (card != null)
            {
                current += card.gold;
                Debug.Log("Selected Card: " + card.name + ", Gold: " + card.gold);

                // You may want to add additional logic here based on your requirements

                break; // Stop the loop after selecting the first matching card
            }
        }

        Debug.Log("Total Gold: " + current);
    }
    public List<Cards> getMaxGold(Dictionary<string, Cards> cardDictionary)
    {
        // Get all cards from the dictionary
        List<Cards> allCards = new List<Cards>(cardDictionary.Values);

        // Sort the cards in descending order based on the gold property
        allCards.Sort((card1, card2) => card2.gold.CompareTo(card1.gold));

        List<Cards> selectedCards = new List<Cards>();
        int currentGold = 0;

        // Select cards
        foreach (Cards card in allCards)
        {
            if (currentGold + card.gold <= maxGold)
            {
                selectedCards.Add(card);
                currentGold += card.gold;
            }
        }

        return selectedCards;
    }

    public void displayBestCards(Dictionary<string, Cards> cardDictionary)
    {
        List<Cards> bestCards = getMaxGold(cardDictionary);

        foreach (Cards card in bestCards)
        {
            Debug.Log("Card Name: " + card.name + ", Gold: " + card.gold);
        }
    }*/
}
