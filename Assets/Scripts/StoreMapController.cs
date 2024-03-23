using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class StoreMapController : MonoBehaviour
{
    [SerializeField] GameObject StorePanel;
    [SerializeField] GameObject StorePromptPanel;
    public dataUseDB dataHandler;

    public Button YesBtn, NoBtn;
    public Button StoreScooter, StoreBike, StoreUnicorn, StoreKite, StorePS, StoreTab;
    public Image Tab, PS, Unicorn, Kite, Scooter, Bike;
    public int newcoinCount;
    public int newstarCount;
    async void Start()
    {
        await InitializeStoreButtons();
    }

    void Update()
    {
        // UpdateStoreButtonInteractability();
    }
    public void Store()
    {
        StorePanel.SetActive(true);
    }
    public void CloseBtn()
    {
        StorePanel.SetActive(false);
    }
    async Task InitializeStoreButtons()
    {
        await dataHandler.RetrieveUserData();

        // Now that data is available, initialize store buttons
        await UpdateStoreButtonInteractability();
    }

    async Task UpdateStoreButtonInteractability()
    {
        // Wait for the task to complete and get the user coins
        int userCoins = await dataHandler.getUserCoins();

        // Update Unicorn and Bike
        StoreUnicorn.interactable = userCoins >= 250;
        StoreBike.interactable = userCoins >= 250;

        // Update Scooter and Kite
        StoreScooter.interactable = userCoins >= 150;
        StoreKite.interactable = userCoins >= 150;

        // Update PS and Tab
        int userStar = await dataHandler.getUserStar();
        StorePS.interactable = userStar >= 32;
        StoreTab.interactable = userStar >= 27;
    }
    void ShowStorePrompt(Image cardToShow)
    {
        StorePromptPanel.SetActive(true);

        Tab.gameObject.SetActive(false);
        PS.gameObject.SetActive(false);
        Unicorn.gameObject.SetActive(false);
        Kite.gameObject.SetActive(false);
        Scooter.gameObject.SetActive(false);
        Bike.gameObject.SetActive(false);

        cardToShow.gameObject.SetActive(true);

        YesBtn.gameObject.SetActive(true);
        NoBtn.gameObject.SetActive(true);
    }

    public void OnClickTab()
    {
        ShowStorePrompt(Tab);
    }

    public void OnClickPS()
    {
        ShowStorePrompt(PS);
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

    public async void OnClickYesBtn()
    {
        int userCoins = await dataHandler.getUserCoins();
        int userStar = await dataHandler.getUserStar();

        if (dataHandler != null && Unicorn.gameObject.activeSelf)
        {
            // Unicorn
            newcoinCount = userCoins - 250;

            //update text ui
            dataHandler.textCoins.text = newcoinCount.ToString();

            // Update the database
            await dataHandler.UpdateUserCoinsAndStars(newcoinCount, userCoins);

            //close panel
            StorePromptPanel.SetActive(false);
        }
        else if (dataHandler != null && Bike.gameObject.activeSelf)
        {
            // Bike
            newcoinCount = userCoins - 250;

            //update text ui
            dataHandler.textCoins.text = newcoinCount.ToString();
            
            // Update the database
            await dataHandler.UpdateUserCoinsAndStars(newcoinCount, userCoins);

            //close panel
            StorePromptPanel.SetActive(false);
        }
        else if (dataHandler != null && Scooter.gameObject.activeSelf)
        {
            // Scooter
            newcoinCount = userCoins - 150;

            //update text ui
            dataHandler.textCoins.text = newcoinCount.ToString();

            // Update the database
            await dataHandler.UpdateUserCoinsAndStars(newcoinCount, userCoins);

            //close panel
            StorePromptPanel.SetActive(false);
        }
        else if (dataHandler != null && Kite.gameObject.activeSelf)
        {
            // Kite
            newcoinCount = userCoins - 150;

            //update text ui
            dataHandler.textCoins.text = newcoinCount.ToString();

            // Update the database
            await dataHandler.UpdateUserCoinsAndStars(newcoinCount, userCoins);

            //close panel
            StorePromptPanel.SetActive(false);
        }
        else if (dataHandler != null && Tab.gameObject.activeSelf)
        {
            // Tab
            newstarCount = userStar - 27;

            //update text ui
            dataHandler.textStar.text = newstarCount.ToString();

            // Update the database
            await dataHandler.UpdateUserCoinsAndStars(userStar, newstarCount);

            //close panel
            StorePromptPanel.SetActive(false);
        }
        else if (dataHandler != null && PS.gameObject.activeSelf)
        {
            // PS
            newstarCount = userStar - 32;

            //update text ui
            dataHandler.textStar.text = newstarCount.ToString();

            // Update the database
            await dataHandler.UpdateUserCoinsAndStars(userStar, newstarCount);

            //close panel
            StorePromptPanel.SetActive(false);
        }

        // Update button interactability
        await UpdateStoreButtonInteractability();
}
    public void OnClickNoBtn()
    {
        StorePromptPanel.SetActive(false);
    }
}