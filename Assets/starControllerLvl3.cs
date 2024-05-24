using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using System.Threading.Tasks;
using Firebase.Auth;

public class StarControllerLvl3 : MonoBehaviour
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
    private DatabaseReference databaseReference2;
    private DatabaseReference databaseReference3;

    private void Start()
    {
        // Set up Firebase database reference

        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        databaseReference2 = FirebaseDatabase.DefaultInstance.RootReference;
        databaseReference3 = FirebaseDatabase.DefaultInstance.RootReference;





        // Listen for changes in Firebase value
        databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl3Stage1")
            .ValueChanged += HandleValueChanged1;
        databaseReference2.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl3Stage2")
           .ValueChanged += HandleValueChanged2;
        databaseReference3.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl3Stage3")
         .ValueChanged += HandleValueChanged3;






        // Fetch initial value from Firebase
        FetchFirebaseValueLvl1();
        FetchFirebaseValueLvl2();
        FetchFirebaseValueLvl3();

    }

    private async void FetchFirebaseValueLvl1()
    {
        try
        {
            // Fetch value asynchronously
            var dataSnapshot = await databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .Child("addStarLvl3Stage1").GetValueAsync();

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


    private async void FetchFirebaseValueLvl2()
    {
        try
        {
            // Fetch value asynchronously
            var dataSnapshot = await databaseReference2.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .Child("addStarLvl3Stage2").GetValueAsync();

            // Check if data snapshot has a valid value
            if (dataSnapshot != null && dataSnapshot.Exists)
            {
                int starValue = Convert.ToInt32(dataSnapshot.Value);

                // Perform actions based on the star value
                switch (starValue)


                {

                    case 0:
                        // Perform actions when star value is 1
                        Debug.Log("FetchFirebaseValueLvl2 Star value is 0");
                        // Add your code here for when star value is 1
                        star3lvl2.SetActive(false);
                        star2lvl2.SetActive(false);
                        star1lvl2.SetActive(false);
                        star0lvl2.SetActive(true);


                        break;
                    case 1:
                        // Perform actions when star value is 1
                        Debug.Log("FetchFirebaseValueLvl2 Star value is 1");
                        // Add your code here for when star value is 1
                        star3lvl2.SetActive(false);
                        star2lvl2.SetActive(false);
                        star1lvl2.SetActive(true);
                        star0lvl2.SetActive(false);

                        break;
                    case 2:
                        // Perform actions when star value is 2
                        Debug.Log("FetchFirebaseValueLvl2 Star value is 2");
                        // Add your code here for when star value is 2
                        star3lvl2.SetActive(false);
                        star2lvl2.SetActive(true);
                        star1lvl2.SetActive(false);
                        star0lvl2.SetActive(false);
                        break;
                    case 3:
                        // Perform actions when star value is 3
                        Debug.Log(" FetchFirebaseValueLvl2 Star value is 3");
                        // Add your code here for when star value is 3
                        star3lvl2.SetActive(true);
                        star2lvl2.SetActive(false);
                        star1lvl2.SetActive(false);
                        star0lvl2.SetActive(false);
                        break;
                    case 4:
                        // Perform actions when star value is 3
                        Debug.Log("FetchFirebaseValueLvl2 Star value is 4");
                        // Add your code here for when star value is 3
                        star3lvl2.SetActive(true);
                        star2lvl2.SetActive(false);
                        star1lvl2.SetActive(false);
                        star0lvl2.SetActive(false);
                        break;
                    case 5:
                        // Perform actions when star value is 3
                        Debug.Log("FetchFirebaseValueLvl2 Star value is 5");
                        // Add your code here for when star value is 3
                        star3lvl2.SetActive(true);
                        star2lvl2.SetActive(false);
                        star1lvl2.SetActive(false);
                        star0lvl2.SetActive(false);
                        break;
                    case 6:
                        // Perform actions when star value is 3
                        Debug.Log("Star value is 6");
                        // Add your code here for when star value is 3
                        star3lvl2.SetActive(true);
                        star2lvl2.SetActive(false);
                        star1lvl2.SetActive(false);
                        star0lvl2.SetActive(false);
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

    private async void FetchFirebaseValueLvl3()
    {
        try
        {
            // Fetch value asynchronously
            var dataSnapshot = await databaseReference3.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .Child("addStarLvl3Stage3").GetValueAsync();

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
                        star3lvl3.SetActive(false);
                        star2lvl3.SetActive(false);
                        star1lvl3.SetActive(false);
                        star0lvl3.SetActive(true);


                        break;
                    case 1:
                        // Perform actions when star value is 1
                        Debug.Log("Star value is 1");
                        // Add your code here for when star value is 1
                        star3lvl3.SetActive(false);
                        star2lvl3.SetActive(false);
                        star1lvl3.SetActive(true);
                        star0lvl3.SetActive(false);

                        break;
                    case 2:
                        // Perform actions when star value is 2
                        Debug.Log("Star value is 2");
                        // Add your code here for when star value is 2
                        star3lvl3.SetActive(false);
                        star2lvl3.SetActive(true);
                        star1lvl3.SetActive(false);
                        star0lvl3.SetActive(false);
                        break;
                    case 3:
                        // Perform actions when star value is 3
                        Debug.Log("Star value is 3");
                        // Add your code here for when star value is 3
                        star3lvl3.SetActive(true);
                        star2lvl3.SetActive(false);
                        star1lvl3.SetActive(false);
                        star0lvl3.SetActive(false);
                        break;
                    case 4:
                        // Perform actions when star value is 3
                        Debug.Log("Star value is 4");
                        // Add your code here for when star value is 3
                        star3lvl3.SetActive(true);
                        star2lvl3.SetActive(false);
                        star1lvl3.SetActive(false);
                        star0lvl3.SetActive(false);
                        break;
                    case 5:
                        // Perform actions when star value is 3
                        Debug.Log("Star value is 5");
                        // Add your code here for when star value is 3
                        star3lvl3.SetActive(true);
                        star2lvl3.SetActive(false);
                        star1lvl3.SetActive(false);
                        star0lvl3.SetActive(false);
                        break;
                    case 6:
                        // Perform actions when star value is 3
                        Debug.Log("Star value is 6");
                        // Add your code here for when star value is 3
                        star3lvl3.SetActive(true);
                        star2lvl3.SetActive(false);
                        star1lvl3.SetActive(false);
                        star0lvl3.SetActive(false);
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

    private void HandleValueChanged3(object sender, ValueChangedEventArgs args)
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