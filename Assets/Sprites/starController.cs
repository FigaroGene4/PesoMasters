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

        // Listen for changes in Firebase value for Stage 1
        databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl1Stage1")
            .ValueChanged += HandleValueChanged;

        // Listen for changes in Firebase value for Stage 2
        databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl1Stage2")
            .ValueChanged += HandleValueChanged;

        // Listen for changes in Firebase value for Stage 3
        databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId).Child("addStarLvl1Stage3")
            .ValueChanged += HandleValueChanged;

        // Fetch initial value from Firebase
        FetchFirebaseValue("addStarLvl1Stage1");
        FetchFirebaseValue("addStarLvl1Stage2");
        FetchFirebaseValue("addStarLvl1Stage3");
    }

    private async void FetchFirebaseValue(string stage)
    {
        try
        {
            // Fetch value asynchronously
            var dataSnapshot = await databaseReference.Child("users").Child(FirebaseAuth.DefaultInstance.CurrentUser.UserId)
                .Child(stage).GetValueAsync();

            // Check if data snapshot has a valid value
            if (dataSnapshot != null && dataSnapshot.Exists)
            {
                int starValue = Convert.ToInt32(dataSnapshot.Value);

                // Perform actions based on the star value
                switch (stage)
                {
                    case "addStarLvl1Stage1":
                        SetStarsActive(starValue, star3, star2, star1, star0);
                        break;
                    case "addStarLvl1Stage2":
                        SetStarsActive(starValue, star3lvl2, star2lvl2, star1lvl2, star0lvl2);
                        break;
                    case "addStarLvl1Stage3":
                        SetStarsActive(starValue, star3lvl3, star2lvl3, star1lvl3, star0lvl3);
                        break;
                    default:
                        Debug.LogWarning($"Unknown stage: {stage}");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error fetching Firebase value for {stage}: {e.Message}");
        }
    }

    private void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        string stage = ((DatabaseReference)sender).Key;
        int starValue = Convert.ToInt32(args.Snapshot.Value);

        Debug.Log($"Star value is {starValue} for {stage}");

        // Additional logic can be added here if necessary
    }

    private void SetStarsActive(int starValue, GameObject star3, GameObject star2, GameObject star1, GameObject star0)
    {
        switch (starValue)
        {
            case 0:
                star3.SetActive(false);
                star2.SetActive(false);
                star1.SetActive(false);
                star0.SetActive(true);
                break;
            case 1:
                star3.SetActive(false);
                star2.SetActive(false);
                star1.SetActive(true);
                star0.SetActive(false);
                break;
            case 2:
                star3.SetActive(false);
                star2.SetActive(true);
                star1.SetActive(false);
                star0.SetActive(false);
                break;
            case 3:
                star3.SetActive(true);
                star2.SetActive(false);
                star1.SetActive(false);
                star0.SetActive(false);
                break;
            case 4:
            case 5:
            case 6:
                star3.SetActive(true);
                star2.SetActive(false);
                star1.SetActive(false);
                star0.SetActive(false);
                break;
            default:
                Debug.LogWarning("Unknown star value: " + starValue);
                break;
        }
    }
}
