using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using System.Threading.Tasks;
using Firebase.Auth;

public class StarControllerMap : MonoBehaviour
{
    public GameObject star3;
    public GameObject star2;
    public GameObject star1;
    public GameObject star0;

    public GameObject star3lvl2;
    public GameObject star2lvl2;
    public GameObject star1lvl2;
    public GameObject star0lvl2;

    public GameObject star3lvl3;
    public GameObject star2lvl3;
    public GameObject star1lvl3;
    public GameObject star0lvl3;


    public string firebaseReference;

    private DatabaseReference databaseReference;

    private void Start()
    {
        // Set up Firebase database reference

        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        // Listen for changes in Firebase value
        databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl1Stage1")
            .ValueChanged += HandleValueChanged;

        // Fetch initial value from Firebase
        FetchFirebaseValue();
    }

    private async void FetchFirebaseValue()
    {
        try
        {
            // Fetch value asynchronously
            var dataSnapshot = await databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .Child("addStarLvl1Stage1").GetValueAsync();

            // Check if data snapshot has a valid value
            if (dataSnapshot != null && dataSnapshot.Exists)
            {
                int starValue = Convert.ToInt32(dataSnapshot.Value);

                // Perform actions based on the star value
                switch (starValue)


                {

                    case 0:
                        // Perform actions when star value is 1
                        Debug.Log("Star value is 0");
                        // Add your code here for when star value is 1
                        star3.SetActive(false);
                        star2.SetActive(false);
                        star1.SetActive(false);
                        star0.SetActive(true);


                        break;
                    case 1:
                        // Perform actions when star value is 1
                        Debug.Log("Star value is 1");
                        // Add your code here for when star value is 1
                        star3.SetActive(false);
                        star2.SetActive(false);
                        star1.SetActive(true);
                        star0.SetActive(false);


                        break;
                    case 2:
                        // Perform actions when star value is 2
                        Debug.Log("Star value is 2");
                        // Add your code here for when star value is 2
                        star3.SetActive(false);
                        star2.SetActive(true);
                        star1.SetActive(false);
                        star0.SetActive(false);
                        break;
                    case 3:
                        // Perform actions when star value is 3
                        Debug.Log("Star value is 3");
                        // Add your code here for when star value is 3
                        star3.SetActive(true);
                        star2.SetActive(false);
                        star1.SetActive(false);
                        star0.SetActive(false);
                        break;
                    case 4:
                        // Perform actions when star value is 3
                        Debug.Log("Star value is 4");
                        // Add your code here for when star value is 3
                        star3.SetActive(true);
                        star2.SetActive(false);
                        star1.SetActive(false);
                        star0.SetActive(false);
                        break;
                    case 5:
                        // Perform actions when star value is 3
                        Debug.Log("Star value is 5");
                        // Add your code here for when star value is 3
                        star3.SetActive(true);
                        star2.SetActive(false);
                        star1.SetActive(false);
                        star0.SetActive(false);
                        break;
                    case 6:
                        // Perform actions when star value is 3
                        Debug.Log("Star value is 6");
                        // Add your code here for when star value is 3
                        star3.SetActive(false);
                        star2.SetActive(true);
                        star1.SetActive(false);
                        star0.SetActive(false);
                        break;


                    default:
                        // Handle other cases if needed
                        Debug.LogWarning("Unknown star value: " + starValue);
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error fetching Firebase value: " + e.Message);
        }
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        // Check the value from Firebase
        int starValue = Convert.ToInt32(args.Snapshot.Value);

        // Perform actions based on the star value
        switch (starValue)
        {
            case 1:
                // Perform actions when star value is 1
                Debug.Log("Star value is 1");
                // Add your code here for when star value is 1
                break;
            case 2:
                // Perform actions when star value is 2
                Debug.Log("Star value is 2");
                // Add your code here for when star value is 2
                break;
            case 3:
                // Perform actions when star value is 3
                Debug.Log("Star value is 3");
                // Add your code here for when star value is 3
                break;
            case 4:
                // Perform actions when star value is 3
                Debug.Log("Star value is 4");
                // Add your code here for when star value is 3
                break;
            case 5:
                // Perform actions when star value is 3
                Debug.Log("Star value is 5");
                // Add your code here for when star value is 3
                break;
            case 6:
                // Perform actions when star value is 3
                Debug.Log("Star value is 6");
                // Add your code here for when star value is 3
                break;
            default:
                // Handle other cases if needed
                Debug.LogWarning("Unknown star value: " + starValue);
                break;
        }
    }
}