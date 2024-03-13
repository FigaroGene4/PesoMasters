using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class StoreController : MonoBehaviour
{
    [SerializeField] GameObject StorePanel;
    [SerializeField] GameObject StorePromptPanel;

    //Need ng function sa pag add ng cards pag bumili si user ng cards
    public CoinsBar coinBar;
    public StarBar starBar;
    public EnergyBar energyBar;
    public Button YesBtn, NoBtn;
    public Button StoreEnergy, StoreCoins, StoreInc, StoreExp, StoreChallenge, StoreBonus; //store buttons
    public Image BonusCard, ChallengeCard, IncomeCard, ExpenseCard, InstantEnergy, InstantCoins; //image prompts when button is clicked

    public int newStarCurrent;
    public int newCoinCurrent;
    public int newCoinCount;
    public int newEnergyCurrent;
    public int newEnergyCount;
    public int GONewScoreCount;
    public int SGNewScoreCount;

    void Start()
    {
        InitializeStoreButtons();
    }

    void Update()
    {
        UpdateStoreButtonInteractability();
    }

    void InitializeStoreButtons()
    {
        StorePanel.SetActive(false);
        StorePromptPanel.SetActive(false);
        YesBtn.gameObject.SetActive(false);
        NoBtn.gameObject.SetActive(false);

        // Initial interactability setup
        StoreEnergy.interactable = false;
        StoreCoins.interactable = false;
        StoreInc.interactable = false;
        StoreExp.interactable = false;
        StoreChallenge.interactable = false;
        StoreBonus.interactable = false;

        if (coinBar.current >= 15)
        {
            StoreExp.interactable = true;
            StoreInc.interactable = true;
        }

        if (coinBar.current >= 25)
        {
            StoreEnergy.interactable = true;
            StoreBonus.interactable = true;
        }

        if (coinBar.current >= 30)
        {
            StoreChallenge.interactable = true;
        }

        if (starBar.current >= 2)
        {
            StoreCoins.interactable = true;
        }
    }

    void UpdateStoreButtonInteractability()
    {
        // Update StoreEnergy and StoreBonus
        StoreEnergy.interactable = coinBar.current >= 25;
        StoreBonus.interactable = coinBar.current >= 25;

        // Update StoreChallenge
        StoreChallenge.interactable = coinBar.current >= 30;

        // Update StoreInc and StoreExp
        StoreInc.interactable = coinBar.current >= 15;
        StoreExp.interactable = coinBar.current >= 15;

        // Update StoreCoins
        StoreCoins.interactable = starBar.current >= 2;
    }


    public void Store()
    {
        StorePanel.SetActive(true);
    }

    public void CloseBtn()
    {
        StorePanel.SetActive(false);
    }

    void ShowStorePrompt(Image cardToShow)
    {
        StorePromptPanel.SetActive(true);

        BonusCard.gameObject.SetActive(false);
        ChallengeCard.gameObject.SetActive(false);
        IncomeCard.gameObject.SetActive(false);
        ExpenseCard.gameObject.SetActive(false);
        InstantEnergy.gameObject.SetActive(false);
        InstantCoins.gameObject.SetActive(false);

        cardToShow.gameObject.SetActive(true);

        YesBtn.gameObject.SetActive(true);
        NoBtn.gameObject.SetActive(true);
    }
    public void OnClickBonus()
    {
        ShowStorePrompt(BonusCard);
    }

    public void OnClickChallenge()
    {
        ShowStorePrompt(ChallengeCard);
    }

    public void OnClickIncome()
    {
        ShowStorePrompt(IncomeCard);
    }

    public void OnClickExpense()
    {
        ShowStorePrompt(ExpenseCard);
    }

    public void OnClickEnergy()
    {
        ShowStorePrompt(InstantEnergy);
    }

    public void OnClickCoins()
    {
        ShowStorePrompt(InstantCoins);
    }
    public void OnClickYesBtn()
    {
        if (starBar != null && InstantCoins.gameObject.activeSelf) //instant coins
        {
            if (starBar.current >= 2)
            {
                //solve
                newStarCurrent = starBar.current - 2; //minus 2 stars
                starBar.current = newStarCurrent;
                newCoinCurrent = coinBar.current + 30; //plus 30 coins
                coinBar.current = newCoinCurrent;

                //update text ui
                starBar.TotalStar.text = newStarCurrent.ToString();
                coinBar.TotalCoins.text = newCoinCurrent.ToString();
                coinBar.goldText.text = newCoinCount.ToString();
                coinBar.GOyourScore.text = GONewScoreCount.ToString(); //GameOver
                coinBar.SGyourScore.text = SGNewScoreCount.ToString(); //StageClear

                //close panel
                StorePromptPanel.SetActive(false);
            }
        }
        else if (coinBar != null && InstantEnergy.gameObject.activeSelf) //instant energy
        {
            if (coinBar.current >= 25)
            {
                //solve
                newCoinCurrent = coinBar.current - 25; //minus 25 coins
                coinBar.current = newCoinCurrent;
                newEnergyCurrent = energyBar.current + 15; //add 15 energy
                energyBar.current = newEnergyCurrent;

                //update text ui
                coinBar.TotalCoins.text = newCoinCurrent.ToString();
                coinBar.goldText.text = newCoinCount.ToString();
                energyBar.energyText.text = newEnergyCount.ToString();
                coinBar.GOyourScore.text = GONewScoreCount.ToString(); //GameOver
                coinBar.SGyourScore.text = SGNewScoreCount.ToString(); //StageClear
                
                //close panel
                StorePromptPanel.SetActive(false);
            }
        }
        else if (coinBar != null && BonusCard.gameObject.activeSelf) //bonus
        {
            if (coinBar.current >= 25)
            {
                //solve
                newCoinCurrent = coinBar.current - 25; //minus 25 coins
                coinBar.current = newCoinCurrent;
    
                //update text ui
                coinBar.TotalCoins.text = newCoinCurrent.ToString();
                coinBar.goldText.text = newCoinCount.ToString();
                coinBar.GOyourScore.text = GONewScoreCount.ToString(); //GameOver
                coinBar.SGyourScore.text = SGNewScoreCount.ToString(); //StageClear
                //line of code for adding bonus card
    
                //close panel
                StorePromptPanel.SetActive(false);
            }
        }
        else if (coinBar != null && ChallengeCard.gameObject.activeSelf) //challenge
        {
            if (coinBar.current >= 30)
            {
                //solve
                newCoinCurrent = coinBar.current - 30; //minus 30 coins
                coinBar.current = newCoinCurrent;

                //update text ui
                coinBar.TotalCoins.text = newCoinCurrent.ToString();
                coinBar.goldText.text = newCoinCount.ToString();
                coinBar.GOyourScore.text = GONewScoreCount.ToString(); //GameOver
                coinBar.SGyourScore.text = SGNewScoreCount.ToString(); //StageClear
                //line of code for adding challenge card

                //close panel
                StorePromptPanel.SetActive(false);
            }
        }
        else if (coinBar != null && ExpenseCard.gameObject.activeSelf) //expense
        {
            if (coinBar.current >= 15)
            {
                //solve
                newCoinCurrent = coinBar.current - 15; //minus 15 coins
                coinBar.current = newCoinCurrent;

                //update text ui
                coinBar.TotalCoins.text = newCoinCurrent.ToString();
                coinBar.goldText.text = newCoinCount.ToString();
                coinBar.GOyourScore.text = GONewScoreCount.ToString(); //GameOver
                coinBar.SGyourScore.text = SGNewScoreCount.ToString(); //StageClear
                //line of code for adding expense card

                //close panel
                StorePromptPanel.SetActive(false);
            }
        }
        else if (coinBar != null && IncomeCard.gameObject.activeSelf) //income
        {
            if (coinBar.current >= 15)
            {
                //solve
                newCoinCurrent = coinBar.current - 15; //minus 15 coins
                coinBar.current = newCoinCurrent;

                //update text ui
                coinBar.TotalCoins.text = newCoinCurrent.ToString();
                coinBar.goldText.text = newCoinCount.ToString();
                coinBar.GOyourScore.text = GONewScoreCount.ToString(); //GameOver
                coinBar.SGyourScore.text = SGNewScoreCount.ToString(); //StageClear
                //line of code for adding income card

                //close panel
                StorePromptPanel.SetActive(false);
            }
        }
    }
    public void OnClickNoBtn()
    {
        StorePromptPanel.SetActive(false);
    }
}
