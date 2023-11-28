using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    // Add any shared data you want to transfer between scripts here
    public EnergyBar energyBar;
    public Dictionary<GameObject, CardValues> cardValuesDictionary = new Dictionary<GameObject, CardValues>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // AddCardValuesToDictionary method added here
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
}
