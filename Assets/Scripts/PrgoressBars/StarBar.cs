using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

[ExecuteInEditMode()]
public class StarBar : MonoBehaviour
{
    [SerializeField]
    GameObject GameOverPanel;

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
        CheckGoalReached();
    }

    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;
    }

    void CheckGoalReached()
    {
        if (current >= maximum)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameOverPanel.SetActive(true); 
    }
    public void getStar()
    {
        string nameOfCard = drawCards.currCardName;

        if (cardDictionary.TryGetValue(nameOfCard, out Cards card))
        {
            if (card != null )
            {
                current += card.star;
                Debug.Log("Energy:" + card.star);
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
