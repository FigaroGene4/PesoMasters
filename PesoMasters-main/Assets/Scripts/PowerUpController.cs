using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] GameObject StorePanel;
    void Start()
    {
        StorePanel.SetActive(false);
    }

    public void Store()
    {
        StorePanel.SetActive(true);
    }
    public void CloseBtn()
    {
        StorePanel.SetActive(false);
    }
    public void PlusEnergy()
    {
        //StorePanel.SetActive(true);
    }
    public void PlusCoins()
    {
        //StorePanel.SetActive(true);
    }
    public void PlusBonus()
    {
        //StorePanel.SetActive(true);
    }
    public void PlusChallenge()
    {
        //StorePanel.SetActive(true);
    }
    public void PlusIncome()
    {
        //StorePanel.SetActive(true);
    }
    public void PlusExpense()
    {
        //StorePanel.SetActive(true);
    }
}