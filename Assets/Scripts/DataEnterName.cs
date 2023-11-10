using Firebase;
using Firebase.Database;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataEnterName : MonoBehaviour
{
    public TMP_InputField Name;

    private string userID;
    private DatabaseReference dbReference;
    void Start()
    {
        // Get the root reference location of the database.
        userID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser()

    {
        User newUser = new User(Name.text);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }
}