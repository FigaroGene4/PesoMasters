using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Progress;

public class StoreMapController : MonoBehaviour
{
    [SerializeField] GameObject StorePanel;
    [SerializeField] GameObject StorePromptPanel;

    public Button YesBtn, NoBtn;
    public Button StoreScooter, StoreBike, StoreUnicorn, StoreKite, StoreRobot, StoreDoll; //store buttons
    public Image Doll, Robot, Unicorn, Kite, Scooter, Bike; //image prompts when button is clicked

    public int newStarCount;
    public int newCoinCount;

    void Start()
    {
     
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

        Doll.gameObject.SetActive(false);
        Robot.gameObject.SetActive(false);
        Unicorn.gameObject.SetActive(false);
        Kite.gameObject.SetActive(false);
        Scooter.gameObject.SetActive(false);
        Bike.gameObject.SetActive(false);

        cardToShow.gameObject.SetActive(true);

        YesBtn.gameObject.SetActive(true);
        NoBtn.gameObject.SetActive(true);
    }

    public void OnClickDoll()
    {
        ShowStorePrompt(Doll);
    }

    public void OnClickRobot()
    {
        ShowStorePrompt(Robot);
    }

    public void OnClickUnicorn()
    {
        ShowStorePrompt(Unicorn);
    }

    public void OnClickKite()
    {
        ShowStorePrompt(Kite);
    }

    public void OnClickScooter()
    {
        ShowStorePrompt(Scooter);
    }

    public void OnClickBike()
    {
        ShowStorePrompt(Bike);
    }
    public void OnClickYesBtn()
    {
        StorePromptPanel.SetActive(false);
    }
    public void OnClickNoBtn()
    {
        StorePromptPanel.SetActive(false);
    }
}
