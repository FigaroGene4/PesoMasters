using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class LearningController : MonoBehaviour
{
    public PanelController panelController;
    public float panelDuration = 2f;

    [SerializeField] GameObject Hello, Money, Allowance, Earn, Savings, Spend, Donate, Click;
    public Button helloBtn, moneyBtn, allowanceBtn, earnBtn, savingsBtn, spendBtn, donateBtn;

    void Start()
    {
        Hello.SetActive(true);

        Money.SetActive(false);
        Allowance.SetActive(false);
        Earn.SetActive(false);
        Savings.SetActive(false);
        Spend.SetActive(false);
        Donate.SetActive(false);
        Click.SetActive(false);
    }

    public void HelloFunction (){
        
        Hello.SetActive(false);

        Money.SetActive(true);
    }
    public void MoneyFunction (){

        Money.SetActive(false);

        Allowance.SetActive(true);
    } 
    public void AllowanceFunction (){

        Allowance.SetActive(false);

        Earn.SetActive(true);
    }
    public void EarnFunction (){

        Earn.SetActive(false);

        Savings.SetActive(true);
    }
    public void SavingsFunction (){

        Savings.SetActive(false);

        Spend.SetActive(true);
    }
    public void SpendFunction (){

        Spend.SetActive(false);

        Donate.SetActive(true);
    }
    public void DonateFunction (){

        Donate.SetActive(false);
        panelController.ShowPanelForDuration(panelDuration);
    }
}
