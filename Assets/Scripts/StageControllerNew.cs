using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine.UI;

public class StageControllerNew : MonoBehaviour
{
    public Button Lvl1Stage2;
    public Button Lvl1Stage3;
    public string firebaseReference;
    private DatabaseReference databaseReference1;
    private DatabaseReference databaseReference2;

    private void Start()
    {

        databaseReference1 = FirebaseDatabase.DefaultInstance.RootReference;
        databaseReference2 = FirebaseDatabase.DefaultInstance.RootReference;

        databaseReference1.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl1Stage1")
            .ValueChanged += HandleValueChanged1;
        databaseReference2.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl1Stage2")
           .ValueChanged += HandleValueChanged2;
        FetchFirebaseValueLvl1();
        FetchFirebaseValueLvl2();
    }

    private async void FetchFirebaseValueLvl1()
    {
        try
        {
            // Fetch value asynchronously
            var dataSnapshot = await databaseReference1.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .Child("addStarLvl1Stage1").GetValueAsync();

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

                        Debug.Log("Unlocked School Stage");
                        Lvl1Stage2.interactable = true;
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
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                Debug.Log("Lvl1Stage2.interactable = true;");
                break;
            default:
                // Handle other cases if needed
                Debug.LogWarning("Unknown star value: " + starValue);
                break;
        }
    }

    private async void FetchFirebaseValueLvl2()
    {
        try
        {
            // Fetch value asynchronously
            var dataSnapshot = await databaseReference2.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .Child("addStarLvl1Stage2").GetValueAsync();

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

                        Debug.Log("Unlocked Lvl1Stage3");
                        Lvl1Stage3.interactable = true;
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
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                // Perform actions when star value is 1
                Debug.Log("Lvl1Stage3.interactable = true;");
                // Add your code here for when star value is 1
                break;

            default:
                // Handle other cases if needed
                Debug.LogWarning("Unknown star value: " + starValue);
                break;
        }
    }


}