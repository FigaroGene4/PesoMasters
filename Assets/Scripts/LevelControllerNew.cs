using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine.UI;

public class LevelControllerNew : MonoBehaviour
{
    public Button School;
    public string firebaseReference;
    private DatabaseReference databaseReference;


    private void Start()
    {
    
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl1Stage3")
            .ValueChanged += HandleValueChanged1;
        FetchFirebaseValueLvl1();
    }

    private async void FetchFirebaseValueLvl1()
    {
        try
        {
            // Fetch value asynchronously
            var dataSnapshot = await databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .Child("addStarLvl1Stage3").GetValueAsync();

            // Check if data snapshot has a valid value
            if (dataSnapshot != null && dataSnapshot.Exists)
            {
                int starValue = Convert.ToInt32(dataSnapshot.Value);

                // Perform actions based on the star value
                switch (starValue)
                {
                    case 3:
                        
                        Debug.Log("Unlocked School Stage");
                        School.interactable = true;
                        break;
                        
                    default:
                        // Handle other cases if needed
                        Debug.LogWarning("Unknown star value");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error fetching Firebase value: " + e.Message);
        }
    }


    
    private void HandleValueChanged1(object sender, ValueChangedEventArgs args)
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
        
            default:
                // Handle other cases if needed
                Debug.LogWarning("Unknown star value: " + starValue);
                break;
        }
    }

  
}