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

    public Button Level3;
    public string firebaseReference2;
    private DatabaseReference databaseReference2;

    public Button Level4;
    public string firebaseReference4;
    private DatabaseReference databaseReference4;


    public Button Level5;
    public string firebaseReference5;
    private DatabaseReference databaseReference5;


    private void Start()
    {
    //SCHOOL UNLOCK
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl1Stage3")
            .ValueChanged += HandleValueChanged1;
        FetchFirebaseValueLvl1();

        //Level3 Unlock

        databaseReference2 = FirebaseDatabase.DefaultInstance.RootReference;
        databaseReference2.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl2Stage3")
            .ValueChanged += HandleValueChanged2;
        FetchFirebaseValueLvl2();


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
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:

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

    //UNlock level3


     private async void FetchFirebaseValueLvl2()
    {
        try
        {
            // Fetch value asynchronously
            var dataSnapshot = await databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .Child("addStarLvl2Stage3").GetValueAsync();

            // Check if data snapshot has a valid value
            if (dataSnapshot != null && dataSnapshot.Exists)
            {
                int starValue = Convert.ToInt32(dataSnapshot.Value);

                // Perform actions based on the star value
                switch (starValue)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:

                        Debug.Log("Unlocked School Stage");
                        Level3.interactable = true;
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


    
    private void HandleValueChanged2(object sender, ValueChangedEventArgs args)
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