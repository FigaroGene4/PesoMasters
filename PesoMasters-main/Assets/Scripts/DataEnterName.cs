using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

using System;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.Tilemaps;

public class DataEnterName : MonoBehaviour
{

    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    public TMP_InputField Name;
    public TMP_Text warningPrompt;
  

    private DatabaseReference dbeference;

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


    public void EnterName()
    {
        Debug.Log("Name:" + Name.text);

        if (string.IsNullOrEmpty(Name.text))
        {
            Debug.Log("Name field is empty. Please enter a name.");
            warningPrompt.text = "Name field is empty. Please enter a name."; // Set the warning message
            return;
        }

        // Removed the regular expression check for alphabetic characters
        /*
        if (!System.Text.RegularExpressions.Regex.IsMatch(Name.text, @"^[a-zA-Z]+$"))
        {
            Debug.Log("Name field contains invalid characters. Please enter a valid name.");
            warningPrompt.text = "Name field contains invalid characters. Please enter a valid name."; // Set the warning message
            return;
        }
        */

        User = auth.CurrentUser;
        Debug.Log("yserd:" + User.UserId);
        string userName = Name.text;
        Debug.Log(userName);

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        // Check if user exists in the database
        reference.Child("users").Child(User.UserId).GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (!snapshot.Exists)
                {
                    // User does not exist, create a new user
                    DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("users");

                    reference.Child(User.UserId).Child("name").SetValueAsync("");
                    reference.Child(User.UserId).Child("age").SetValueAsync(0);
                }
                else
                {
                    // User exists, update the user's name
                    Dictionary<string, object> dataToUpdate = new Dictionary<string, object>();
                    dataToUpdate["name"] = userName;

                    // Update data in Firebase
                    reference.Child("users").Child(User.UserId).UpdateChildrenAsync(dataToUpdate);
                }
            }
        });

        SceneManager.LoadScene("AgeInput");
    }

}