using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject CardExp1, CardExp2, CardExp3, CardExp4, CardExp5, CardExp6, CardExp7, CardExp8, CardExp9, cardExp10;
    public GameObject CardInc1, CardInc2, CardInc3, CardInc4, CardInc5, CardInc6, CardInc7, CardInc8, CardInc9, CardInc10;
    public GameObject CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10;

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
            CardBonus1, CardBonus2, CardBonus3, CardBonus4, CardBonus5, CardBonus6, CardBonus7, CardBonus8, CardBonus9, CardBonus10
        };
        ShuffleVariables();
    }

    void ShuffleVariables()
    {
        int n = shuffledCards.Length;
        for (int i = n - 1; i > 0; i--)
        {
            // Generate a random index within the remaining unshuffled cards
            int randIndex = Random.Range(0, i + 1);

            // Swap the current card with the randomly selected card
            GameObject temp = shuffledCards[i];
            shuffledCards[i] = shuffledCards[randIndex];
            shuffledCards[randIndex] = temp;
        }

        currentIndex = 0; // Reset the current index to the beginning of the shuffled cards
        sortingOrder = 0; // Reset the sorting order
    }

    public void OnMouseDown()
    {
        if (currentIndex >= shuffledCards.Length)
        {
            // If we have drawn all the cards, do nothing
            return;
        }

        if (currentCard != null)
        {
            Destroy(currentCard); // Destroy the previous card
        }

        Vector3 cardPosition = new Vector3(0, 0, currentIndex * cardOffset);
        currentCard = Instantiate(shuffledCards[currentIndex], cardPosition, Quaternion.identity);
        Debug.Log("Card instantiated: " + shuffledCards[currentIndex].name);

        // Set the sorting order for the card to change its rendering order
        SpriteRenderer spriteRenderer = currentCard.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = sortingOrder;
            sortingOrder++;
        }

        currentIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        // You can add additional logic here if needed
    }
}
