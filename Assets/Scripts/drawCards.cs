using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class DrawCards : MonoBehaviour
{
    public GameObject CardExp1, CardExp2, CardExp3, CardExp4, CardExp5, CardExp6, CardExp7, CardExp8, CardExp9, cardExp10;
    public GameObject CardInc1, CardInc2, CardInc3, CardInc4, CardInc5, CardInc6, CardInc7, CardInc8, CardInc9, CardInc10;
    public GameObject CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10;
    public GameObject CardChallenge1, CardChallenge2, CardChallenge3, CardChallenge4, CardChallenge5, CardChallenge6, CardChallenge7, CardChallenge8;

    private GameObject[] shuffledCards;
    private GameObject currentCard; // Store the currently displayed card
    private int currentIndex = 0;
    private float cardOffset = 0.1f; // Adjust this value to control the spacing between cards
    private int sortingOrder = 0; // Initial sorting order

    void Start()
    {
        currentIndex = 0;
        // Initialize the shuffled cards array and shuffle it initially
        shuffledCards = new GameObject[] { CardExp1, CardExp2, CardExp3, CardExp4, CardExp5, CardExp6, CardExp7, CardExp8, CardExp9, cardExp10, 
            CardInc1, CardInc2, CardInc3, CardInc4, CardInc5, CardInc6, CardInc7, CardInc8, CardInc9, CardInc10,
            CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10,
            CardChallenge1, CardChallenge2, CardChallenge3, CardChallenge4, CardChallenge5, CardChallenge6, CardChallenge7, CardChallenge8
        };
        ShuffleVariables();
    }

    void ShuffleVariables()
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
        if (currentIndex >= shuffledCards.Length)
        {
            return;
        }

        if (currentCard != null)
        {
            Destroy(currentCard);
        }

        Vector3 cardPosition = new Vector3(0, 0, currentIndex * cardOffset);
        currentCard = Instantiate(shuffledCards[currentIndex], cardPosition, Quaternion.identity);
        Debug.Log("Card instantiated: " + shuffledCards[currentIndex].name);

        // Access values from CardValues script
        CardValues cardValues = currentCard.GetComponent<CardValues>();
        if (cardValues != null)
        {
            // Apply the values to your progress bars
            starChange += cardValues.starChange;
            coins += cardValues.coinsChange;
            energy += cardValues.energyChange;
        }

        // Set sorting order
        SetSortingOrder(currentCard);

        currentIndex++;
    }
    void SetSortingOrder(GameObject card)
    {
        SpriteRenderer spriteRenderer = card.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = sortingOrder;
            sortingOrder++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        // You can add additional logic here if needed
    }
}
