using System.Collections;
using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;
using Firebase;

public class learningObj : MonoBehaviour
{
    DatabaseReference databaseReference;
    FirebaseAuth auth;
    FirebaseUser user;

    void Start()
    {
        // Initialize Firebase
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
            auth = FirebaseAuth.DefaultInstance;
            auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
        });
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }

    public void OnMouseDownLearningOb()
    {
        if (user != null)
        {
            StartCoroutine(LogEventAndFetchUserData());
        }
        else
        {
            Debug.LogWarning("User not signed in. Cannot log event.");
        }
    }

    IEnumerator LogEventAndFetchUserData()
    {
        yield return LogEventToFirebase();
        FetchUserData();
    }

    IEnumerator LogEventToFirebase()
    {
        // Check if a user is authenticated
        if (auth.CurrentUser != null)
        {
            // Get the current user's UID
            string uid = auth.CurrentUser.UserId;

            // Create a new entry with the field "clickedTutorialMap" and value "true"
            // under the user's UID node
            var task = databaseReference.Child("users").Child(uid).Child("clickedTutorialMap").SetValueAsync(true);

            // Wait for the task to complete
            yield return new WaitUntil(() => task.IsCompleted);

            if (task.Exception != null)
            {
                Debug.LogError("Failed to set value: " + task.Exception);
            }
            else
            {
                Debug.Log("Field 'clickedTutorialMap' created with value 'true' under user UID in Firebase.");
            }
        }
        else
        {
            Debug.LogError("User is not authenticated.");
        }
    }

    void FetchUserData()
    {
        // Check if a user is authenticated
        if (auth.CurrentUser != null)
        {
            // Get the current user's UID
            string uid = auth.CurrentUser.UserId;

            // Fetch user data from Firebase
            databaseReference.Child("users").Child(uid).GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;

                    // Check if the user data contains the clickedTutorialMap field
                    if (snapshot.HasChild("clickedTutorialMap"))
                    {
                        // Get the value of clickedTutorialMap
                        object clickedTutorialMapValue = snapshot.Child("clickedTutorialMap").Value;

                        // Convert the value to a boolean
                        bool clickedTutorialMapBool = (bool)clickedTutorialMapValue;

                        // If clickedTutorialMap is true, disable the GameObject
                        if (clickedTutorialMapBool)
                        {
                            DisableLearningObjectives();
                        }
                    }
                    else
                    {
                        Debug.LogWarning("User data does not contain clickedTutorialMap field.");
                    }
                }
                else
                {
                    Debug.LogError("Failed to fetch user data: " + task.Exception);
                }
            });
        }
        else
        {
            Debug.LogError("User is not authenticated.");
        }
    }

    void DisableLearningObjectives()
    {
        // Disable the GameObject named "LearningObjectives"
        GameObject learningObjectives = GameObject.Find("LearningObjectives");
        if (learningObjectives != null)
        {
            learningObjectives.SetActive(false);
            Debug.Log("LearningObjectives GameObject disabled.");
        }
        else
        {
            Debug.LogWarning("LearningObjectives GameObject not found.");
        }
    }
}
