using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class CoinsBar : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject StageClearPanel;
    public StarBar starBar;
    public EnergyBar EnergyBar;
    public DrawCards drawCards;
    public countCards countCards;
    public GameController gameController;

    public Text goldText;
    public TextMeshProUGUI GOyourScore; //Game Over Panel
    public TextMeshProUGUI GOmaxScore; //Game Over Panel
    public TextMeshProUGUI SGyourScore; //Stage Clear Panel
    public TextMeshProUGUI SGmaxScore; //Stage Clear Panel

    public int maximum;
    public int current;
    public Image mask;
    public Cards CardExp1, CardExp2, CardExp3, CardExp4, CardExp5, CardExp6, CardExp7, CardExp8, CardExp9, CardExp10,
        CardInc1, CardInc2, CardInc3, CardInc4, CardInc5, CardInc6, CardInc7, CardInc8, CardInc9, CardInc10,
        CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10,
        CardChallenge1, CardChallenge2, CardChallenge3, CardChallenge4, CardChallenge5, CardChallenge6, CardChallenge7, CardChallenge8;

    public Dictionary<string, Cards> cardDictionary;

    void Start()
    {
        InitializeCards();
        GameOverPanel.SetActive(false);
    }
    private void Update()
    {
        GetCurrentFill();
        CheckGameOver();
        CheckGoalReached();
    }
    /*void LatUpdate()
    {
        Debug.Log("Update method called");
        GetCurrentFill();
    }*/

    public void GetCurrentFill()
    {
        //Debug.Log("Coin Fill ");    
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
    void CheckGameOver()
    {
        if (current <= 0)
        {
            GameOverPanel.SetActive(true);
        }
    }
    void CheckGoalReached()
    {
        if (starBar != null && starBar.current >= starBar.maximum && current >= maximum && countCards.clickCount >= 0)
        {
            GameComplete();
        }
        else if (starBar.current < 0 || current <= 0 || countCards.clickCount <= 0 || EnergyBar.current <= 0)
        {
            if (GameOverPanel != null)
            {
                GameOverPanel.SetActive(true);
            }
        }
    }
    void GameComplete()
    {
        gameController.GameCompleted();
        StageClearPanel.SetActive(true);
    }
    void InitializeCards()
    {
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

    Dictionary<string, Cards> knapsackDictionary = new Dictionary<string, Cards>();

    bool isYesButtonClicked = false;

    public void OnButtonClick()
    {
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
        GOyourScore.text = current.ToString(); //GameOver
        SGyourScore.text = current.ToString(); //StageClear
    }

    public void AddToKnapsackDictionary(string cardName, Cards card)
    {
        if (!knapsackDictionary.ContainsKey(cardName))
        {
            knapsackDictionary.Add(cardName, card);
            Debug.Log("Added to knapsackDictionary: " + cardName);
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
        Debug.Log("Max gold: " + result.Item1 + ", Max energy: " + result.Item2);
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
        if (knapsackDictionary.Count > 0)
        {
            int W = 20;
            var result = KnapSack(W, knapsackDictionary);
            Debug.Log("Max gold: " + result.Item1);
            GOmaxScore.text = "Maximum Score: " + result.Item1.ToString();
            SGmaxScore.text = "Maximum Score: " + result.Item1.ToString();
        }
        else
        {
            Debug.Log("Knapsack is empty. Add items before calling GetMax.");
        }
    }

    public void UpdateGoldText()
    {
        goldText.text = current.ToString();
    }
}