using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class HouseController : MonoBehaviour
{
    [SerializeField] GameObject HousePanel;
    [SerializeField] GameObject BookPromptPanel;

    public Button HouseBook, HouseScooter, HouseBike, HouseUnicorn, HouseKite, HousePS, HouseTab;
    public Image Book, Tab, PS, Unicorn, Kite, Scooter, Bike;
    private bool isUnicornBought, isBikeBought, isScooterBought, isKiteBought, isPSBought, isTabBought;
    void Start()
    {
        // Ensure that the HousePanel and BookPromptPanel are initially closed
        CloseHousePanel();
        CloseBookPromptPanel();

        // Disable all the buttons
        HouseUnicorn.interactable = isUnicornBought;
        HouseBike.interactable = isBikeBought;
        HouseScooter.interactable = isScooterBought;
        HouseKite.interactable = isKiteBought;
        HousePS.interactable = isPSBought;
        HouseTab.interactable = isTabBought;
    }

    // Method to open the HousePanel
    public void OpenHousePanel()
    {
        HousePanel.SetActive(true);
    }

    // Method to close the HousePanel
    public void CloseHousePanel()
    {
        HousePanel.SetActive(false);
    }

    // Method to open the BookPromptPanel
    public void OpenBookPromptPanel()
    {
        BookPromptPanel.SetActive(true);
    }

    // Method to close the BookPromptPanel
    public void CloseBookPromptPanel()
    {
        BookPromptPanel.SetActive(false);
    }

    // Method to handle the click event of the Book in the HousePanel
    public void OnHouseClick()
    {
        // Open the BookPromptPanel
        OpenHousePanel();
    }

    // Method to handle the click event of the Book in the HousePanel
    public void OnBookClick()
    {
        // Open the BookPromptPanel
        OpenBookPromptPanel();
    }

    // Method to handle the click event of the CloseBtn in the BookPromptPanel
    public void OnCloseBtnClick()
    {
        // Close the BookPromptPanel
        CloseBookPromptPanel();
        // Open the HousePanel
        OpenHousePanel();
    }

    // Method to handle the click event of the BackBtn in the HousePanel
    public void OnBackBtnClick()
    {
        // Close the HousePanel
        CloseHousePanel();
        // You can add code here to navigate back to the GameMap
    }

    // Methods to update the state of bought items
    public void SetUnicornBought(bool value)
    {
        isUnicornBought = value;
        HouseUnicorn.interactable = value;
    }

    public void SetBikeBought(bool value)
    {
        isBikeBought = value;
        HouseBike.interactable = value;
    }

    public void SetScooterBought(bool value)
    {
        isScooterBought = value;
        HouseScooter.interactable = value;
    }

    public void SetKiteBought(bool value)
    {
        isKiteBought = value;
        HouseKite.interactable = value;
    }

    public void SetPSBought(bool value)
    {
        isPSBought = value;
        HousePS.interactable = value;
    }

    public void SetTabBought(bool value)
    {
        isTabBought = value;
        HouseTab.interactable = value;
    }
}