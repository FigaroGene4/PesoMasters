using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DrawCards : MonoBehaviour
{
    public EnergyBar energyBar;
    public CoinsBar coinsBar;

    public GameObject CardExp1, CardExp2, CardExp3, CardExp4, CardExp5, CardExp6, CardExp7, CardExp8, CardExp9, CardExp10;
    public GameObject CardInc1, CardInc2, CardInc3, CardInc4, CardInc5, CardInc6, CardInc7, CardInc8, CardInc9, CardInc10;
    public GameObject CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10;
    public GameObject CardChallenge1, CardChallenge2, CardChallenge3, CardChallenge4, CardChallenge5, CardChallenge6, CardChallenge7, CardChallenge8;

    public GameObject[] shuffledCards;
    public GameObject currentCard; // Store the currently displayed card
    public string currCardName;
    public int currentIndex = 0;
    public float cardOffset = 0.1f; // Adjust this value to control the spacing between cards
    public int sortingOrder = 0; // Initial sorting order
    public Dictionary<GameObject, CardValues> cardValuesDictionary = new Dictionary<GameObject, CardValues>();
    public List<GameObject> drawnCards = new List<GameObject>();

    void Start()
    {   
        currentIndex = 0;
        // Initialize the shuffled cards array and shuffle it initially
        shuffledCards = new GameObject[] { 
            CardExp1, CardExp2, CardExp3, CardExp4, CardExp5, CardExp6, CardExp7, CardExp8, CardExp9, CardExp10, 
            CardInc1, CardInc2, CardInc3, CardInc4, CardInc5, CardInc6, CardInc7, CardInc8, CardInc9, CardInc10,
            CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10,
            CardChallenge1, CardChallenge2, CardChallenge3, CardChallenge4, CardChallenge5, CardChallenge6, CardChallenge7, CardChallenge8
        };
        ShuffleVariables();
    }

    public GameObject GetCurrentCard()
    {
        return currentCard;
    }

    public CardValues GetCurrentCardValues()
    {
        if (currentCard != null && cardValuesDictionary.ContainsKey(currentCard))
        {
            return cardValuesDictionary[currentCard];
        }

        return null;
    }

    public void InitializeCardValuesDictionary()
    {
        // Instead of adding values to cardValuesDictionary, add them to DataManager
        DataManager.Instance.AddCardValuesToDictionary(CardExp1, 1, -3);
        DataManager.Instance.AddCardValuesToDictionary(CardExp2, 2, -3);
        DataManager.Instance.AddCardValuesToDictionary(CardExp3, 2, -3);
        DataManager.Instance.AddCardValuesToDictionary(CardExp4, 1, -2);
        DataManager.Instance.AddCardValuesToDictionary(CardExp5, 3, -7);
        DataManager.Instance.AddCardValuesToDictionary(CardExp6, 1, -2);
        DataManager.Instance.AddCardValuesToDictionary(CardExp7, 1, -2);
        DataManager.Instance.AddCardValuesToDictionary(CardExp8, 3, -2);
        DataManager.Instance.AddCardValuesToDictionary(CardExp9, 2, -2);
        DataManager.Instance.AddCardValuesToDictionary(CardExp10, 3, -5);

        DataManager.Instance.AddCardValuesToDictionary(CardInc1, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardInc2, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardInc3, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardInc4, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardInc5, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardInc6, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardInc7, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardInc8, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardInc9, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardInc10, 1, 1);

        DataManager.Instance.AddCardValuesToDictionary(CardBonus1, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardBonus2, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardBonus3, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardBonus4, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardBonus5, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardBonus6, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardBonus7, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardBonus8, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardBonus9, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardBonus10, 1, 1);

        DataManager.Instance.AddCardValuesToDictionary(CardChallenge1, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardChallenge2, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardChallenge3, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardChallenge4, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardChallenge5, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardChallenge6, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardChallenge7, 1, 1);
        DataManager.Instance.AddCardValuesToDictionary(CardChallenge8, 1, 1);
        // ... Repeat for other card types
    }

    public void AddCardValuesToDictionary(GameObject cardType, int energyChange, int goldChange)
    {
        CardValues cardValues = cardType.GetComponent<CardValues>();
        if (cardValues != null)
        {
            cardValues.energyChange = energyChange;
            cardValues.goldChange = goldChange;
            cardValuesDictionary.Add(cardType, cardValues);
            Debug.Log("Added values for card: " + cardType.name);
        }
        else
        {
            Debug.LogError("CardValues component not found on card: " + cardType.name);
        }
    }

    //FISCHER-YATES

    public void ShuffleVariables()
    {
        int n = shuffledCards.Length;
        for (int i = n - 1; i > 0; i--)
        {
            int randIndex = Random.Range(0, i + 1);
            GameObject temp = shuffledCards[i];
            shuffledCards[i] = shuffledCards[randIndex];
            shuffledCards[randIndex] = temp;
        }

        currentIndex = 0;
        sortingOrder = 0;
    }

    public void OnMouseDown()
    {
        if (currentIndex >= 20)
        {
            return;
        }

        if (currentCard != null)
        {
            Destroy(currentCard);
        }

        Vector3 cardPosition = new Vector3(0, -1, currentIndex * cardOffset);
        currentCard = Instantiate(shuffledCards[currentIndex], cardPosition, Quaternion.identity);
        currCardName = shuffledCards[currentIndex].name;

        // Save the drawn card
        drawnCards.Add(currentCard);

        SetSortingOrder(currentCard);

        currentIndex++;
    }

    public void SetSortingOrder(GameObject card)
    {
        SpriteRenderer spriteRenderer = card.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = sortingOrder;
            sortingOrder++;
        }
    }    
}
