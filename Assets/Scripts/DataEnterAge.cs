using Firebase;
using Firebase.Database;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Firebase.Auth;
using System.Collections.Generic;

public class DataEnterAge : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    public Slider ageSlider;
    public TMP_Text ageText;
    private string userAge;
    private DatabaseReference dbReference;

    void Start()
    {
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;


        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
                SetAuthEmulatorEnvironmentVariable();

            }
            else
            {
                Debug.LogError($"Failed to initialize Firebase with {dependencyStatus}");
            }
        });
        //userAge = SystemInfo.deviceUniqueIdentifier;
        //dbReference = FirebaseDatabase.DefaultInstance.RootReference;

        ageSlider.onValueChanged.AddListener(delegate { UpdateAge(); });

        UpdateAge();
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;

    }

    private void SetAuthEmulatorEnvironmentVariable()
    {
#if UNITY_EDITOR
        // In the Unity Editor, set USE_AUTH_EMULATOR to true during development
        Debug.Log("Setting USE_AUTH_EMULATOR to true for development");
        System.Environment.SetEnvironmentVariable("USE_AUTH_EMULATOR", "true");
#endif
    }

    void UpdateAge()
    {
        int birthYear = (int)ageSlider.value;
        ageText.text = "Year: " + birthYear.ToString();

        // Calculate the current year
        int currentYear = DateTime.Now.Year;

        // Calculate the age
        int age = currentYear - birthYear;

        // Store the age in Firebase
        StoreUserAge(age);
    }

    public void StoreUserAge(int age)
    {
        Firebase.Auth.FirebaseAuth auth;
        Firebase.Auth.FirebaseUser User;

        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        User = auth.CurrentUser;

        var userAge = new Dictionary<string, object>
    {
        { "age", age.ToString() }
    };

        Firebase.Database.DatabaseReference dbReference = Firebase.Database.FirebaseDatabase.DefaultInstance.RootReference;
        dbReference.Child("users").Child(User.UserId).UpdateChildrenAsync(userAge);
    }
}
