using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public Dictionary<string, CardValues> cardValuesDictionary = new Dictionary<string, CardValues>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeCardValues();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeCardValues()
    {
        // Example of adding card values, adjust accordingly
        AddCardValuesToDictionary("CardExp1", new CardValues { goldChange = 1, energyChange = -3, starChange = 1 });
        // Add other cards as needed...
    }

    public void AddCardValuesToDictionary(string cardName, CardValues cardValues)
    {
        if (!cardValuesDictionary.ContainsKey(cardName))
        {
            cardValuesDictionary[cardName] = cardValues;
        }
    }

    public CardValues GetCardValuesByName(string cardName)
    {
        if (cardValuesDictionary.TryGetValue(cardName, out var cardValues))
        {
            return cardValues;
        }
        return null;
    }
}
