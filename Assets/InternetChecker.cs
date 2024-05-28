using UnityEngine;
using UnityEngine.UI;

public class InternetChecker : MonoBehaviour
{
    public GameObject gameUI, learningObj;
    public GameObject noInternetUI;
    
   public void Start()
    {
        CheckInternetConnection();
    }

   public void Update(){
         CheckInternetConnection(); 
    }

    void CheckInternetConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            // No internet connection
            gameUI.SetActive(false); // Disable game UI
            learningObj.SetActive(false);
            noInternetUI.SetActive(true); // Enable UI indicating no internet
            Debug.Log("No Internet");
        }
        else
        {
            // Internet connection available
            gameUI.SetActive(true); // Enable game UI
            noInternetUI.SetActive(false); // Disable UI indicating no internet
        }
    }
}
