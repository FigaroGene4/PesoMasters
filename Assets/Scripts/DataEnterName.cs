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
        User = auth.CurrentUser;
        Debug.Log("yserd" + User.UserId);
        string userName = Name.text;
        Debug.Log(userName);

       
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;


        // Data to update
        Dictionary<string, object> dataToUpdate = new Dictionary<string, object>();
        dataToUpdate["name"] = userName;

        // Update data in Firebase
        reference.Child("users").Child(User.UserId).UpdateChildrenAsync(dataToUpdate);
    }
}