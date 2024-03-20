using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

[ExecuteInEditMode()]
public class StarBar : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject StageClearPanel;
    public CoinsBar coinsBar;
    public StarsEarnedSC starsEarnedSC;
    public StarsEarnedGO starsEarnedGO;
    public countCards countCards;
    public EnergyBar EnergyBar;
    public GameController gameController;
    public Image[] stars;
    public Sprite yellowStarSprite;
    public Sprite grayStarSprite;
    public TextMeshProUGUI TotalStar; //Store Total Current Star
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

    // Start is called before the first frame update
    void Start()
    {
        InitializeCards();
        GameOverPanel.SetActive(false);
        StageClearPanel.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
   /*     CheckGoalReached();*/
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;

        // Calculate the number of stars to display based on the current value
        int filledStars = Mathf.FloorToInt(fillAmount * stars.Length);

        // Change sprite of stars based on current value
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
        TotalStar.text = current.ToString();
    }

   /* void CheckGoalReached()
    {
        if (coinsBar != null && coinsBar.current >= coinsBar.maximum && current >= maximum && countCards.clickCount >= 0)
        {
            //check if coin bar current is equal to max, and star bar is equal to max and click count is <= to 0
            GameComplete();
        }
        else if (coinsBar.current <= 0 || current < 0 || countCards.clickCount <= 0 || EnergyBar.current <= 0)
        {
            if (GameOverPanel != null)
            {
                GameOverPanel.SetActive(true);
            }
        }
    }*/

    void GameComplete()
    {
        StageClearPanel.SetActive(true);
    }
    
    public void getStar()
    {
        string nameOfCard = drawCards.currCardName;

        if (cardDictionary.TryGetValue(nameOfCard, out Cards card))
        {
            if (card != null )
            {
                current += card.star;
                Debug.Log("Star:" + card.star);
            }
            else
            {
                Debug.Log(nameOfCard + " or " + nameOfCard + ".star is null");
            }
        }
        else
        {
            Debug.Log("Card not found: " + nameOfCard);
        }

        if (drawCards != null && drawCards.currCardName != null)
        {
            // Debug.Log("Cur" + drawCards.currCardName);
        }
        else
        {
            Debug.Log("drawCards or drawCards.currentCard is null");
        }
    }
}