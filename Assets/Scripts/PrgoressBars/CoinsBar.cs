using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class CoinsBar : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject StageClearPanel;
    public StarBar starBar;
    public StarsEarnedSC starsEarnedSC; 
    public StarsEarnedGO starsEarnedSGO; 
    public EnergyBar EnergyBar;
    public DrawCards drawCards;
    public countCards countCards;
    public LevelManager levelManager;

    public Text goldText;
    public TextMeshProUGUI GOyourScore; //Game Over Panel
    public TextMeshProUGUI GOmaxScore; //Game Over Panel
    public TextMeshProUGUI SGyourScore; //Stage Clear Panel
    public TextMeshProUGUI SGmaxScore; //Stage Clear Panel
    public TextMeshProUGUI TotalCoins; //Stage Clear Panel

    public int maximum;
    public int current;
    public Image mask;
    public Cards CardExp1, CardExp2, CardExp3, CardExp4, CardExp5, CardExp6, CardExp7, CardExp8, CardExp9, CardExp10,
        CardInc1, CardInc2, CardInc3, CardInc4, CardInc5, CardInc6, CardInc7, CardInc8, CardInc9, CardInc10,
        CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10,
        CardChallenge1, CardChallenge2, CardChallenge3, CardChallenge4, CardChallenge5, CardChallenge6, CardChallenge7, CardChallenge8;

    public Dictionary<string, Cards> cardDictionary;

    public int sum;
    public int userCoins;
    public int neededCoin;
    public int neededStar;

    public dataUseDB dataUseDB;
    public dataSaveDB dataSaveDB;
    public string dbNameCoins;
    public string dbNameStar;

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser User;

    void Start()
    {
        InitializeCards();
        GameOverPanel.SetActive(false);

        string currentSceneName = SceneManager.GetActiveScene().name;

        switch (currentSceneName)
        {
            case "GamesceneLvl1Stage1":
               
                Debug.Log("Executing code for Scene1");

                neededCoin = 60;
                neededStar = 1;
                dbNameStar = "addStarLvl1Stage1";



                break;
            case "GamesceneLvl1Stage2":

                neededCoin = 70;
                neededStar = 2;
                dbNameStar = "addStarLvl1Stage2";
                Debug.Log("Executing code for Scene2");
                break;
            case "GamesceneLvl1Stage3":
              
                Debug.Log("Executing code for Scene3");
                neededCoin = 80;
                neededStar = 3;
                dbNameStar = "addStarLvl1Stage3";
                break;

            case "GamesceneLvl2Stage1":

                Debug.Log("Executing code for Scene3");
                neededCoin = 65;
                neededStar = 1;
                dbNameStar = "addStarLvl2Stage1";
                break;
            case "GamesceneLvl2Stage2":

                Debug.Log("Executing code for Scene3");
                neededCoin = 75;
                neededStar = 2;
                dbNameStar = "addStarLvl2Stage2";
                break;
            case "GamesceneLvl2Stage3":

                Debug.Log("Executing code for Scene3");
                neededCoin = 85;
                neededStar = 3;
                dbNameStar = "addStarLvl2Stage3";
                break;


            default:
      
                Debug.Log("No code execution for this scene");
                break;
        }
    }
    private void Update()
    {
        GetCurrentFill();
        CheckGameOver();
        
        
    }

    public void GetCurrentFill()
    {
          
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }
    void CheckGameOver()
    {
        if (current <= 0 || EnergyBar.current <= 0)
        {
            starsEarnedSGO.DisplayStarsEarned(starBar.current);
            GameOverPanel.SetActive(true);
            
        }
    }
    public void CheckGoalReached()
    {
        if (starBar.current >= neededStar && current >= neededCoin && countCards.clickCount <= 0)
        {
            GameComplete();
            dataSaveDB.addStar();
            dataSaveDB.addCoins();
            dataSaveDB.addStarLvl1Stage1();

        }

        else if (starBar.current <= neededStar && current < neededCoin && countCards.clickCount <= 0)
        {
            starsEarnedSGO.DisplayStarsEarned(starBar.current);
            GameOverPanel.SetActive(true);
        }

        else if (starBar.current <= neededStar || current < neededCoin && countCards.clickCount <= 0)
        {
            starsEarnedSGO.DisplayStarsEarned(starBar.current);
            GameOverPanel.SetActive(true);
            
        }

    }
    public void GameComplete()
    {
        starsEarnedSC.DisplayStarsEarned(starBar.current);
        StageClearPanel.SetActive(true);
        LevelManager levelManager = FindObjectOfType<LevelManager>();

        if (levelManager != null)
        {
            int currentStageIndex = SceneManager.GetActiveScene().buildIndex % 3; // Assuming each level has 3 stages

            // Unlock the next stage
            levelManager.UnlockNextStage();

            // If all stages of the current level are completed
            if (levelManager.AreAllStagesOfCurrentLevelCompleted())
            {
                // Unlock the next level
                levelManager.UnlockNextLevel();
            }
        }
        else
        {
            Debug.LogWarning("LevelManager not found in the scene!");
        }
    }


    void InitializeCards()
    {
        // Initialize the dictionary with your Cards instances
        cardDictionary = new Dictionary<string, Cards>
        {
            {"EXPENSE-1", CardExp1},
            {"EXPENSE-2", CardExp2},
            {"EXPENSE-3", CardExp3},
            {"EXPENSE-4", CardExp4},
            {"EXPENSE-5", CardExp5},
            {"EXPENSE-6", CardExp6},
            {"EXPENSE-7", CardExp7},
            {"EXPENSE-8", CardExp8},
            {"EXPENSE-9", CardExp9},
            {"EXPENSE-10", CardExp10},
            {"Income", CardInc1},
            {"Income (2)", CardInc2},
            {"Income (3)", CardInc3},
            {"Income (4)", CardInc4},
            {"Income (5)", CardInc5},
            {"Income (6)", CardInc6},
            {"Income (7)", CardInc7},
            {"Income (8)", CardInc8},
            {"Income (9)", CardInc9},
            {"Income (10)", CardInc10},
            {"BONUS-1", CardBonus1},
            {"BONUS-2 1", CardBonus2},
            {"BONUS-3", CardBonus3},
            {"BONUS-4", CardBonus4},
            {"BONUS-5", CardBonus5},
            {"BONUS-6", CardBonus6},
            {"BONUS-7", CardBonus7},
            {"BONUS-8", CardBonus8},
            {"BONUS-9", CardBonus9},
            {"BONUS-10", CardBonus10},
            {"CHALLENGE-lvl1", CardChallenge1},
            {"CHALLENGE-lvl1 (2)", CardChallenge2},
            {"CHALLENGE-lvl1 (3)", CardChallenge3},
            {"CHALLENGE-lvl1 (4)", CardChallenge4},
            {"CHALLENGE-lvl1 (5)", CardChallenge5},
            {"CHALLENGE-lvl1 (6)", CardChallenge6},
            {"CHALLENGE-lvl2", CardChallenge7},
            {"CHALLENGE-lvl2 (2)", CardChallenge8},
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
        TotalCoins.text = current.ToString(); //StoreCoins
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