using Firebase;
using Firebase.Database;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataEnterAge : MonoBehaviour
{
    public TMP_InputField Age;

    private string userAge;
    private DatabaseReference dbReference;
    void Start()
    {
        // Get the root reference location of the database.
        userAge = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void UserAge()

    {
        User newAge = new User(Age.text);
        string json = JsonUtility.ToJson(newAge);

        dbReference.Child("UserAge").Child(userAge).SetRawJsonValueAsync(json);
    }
}