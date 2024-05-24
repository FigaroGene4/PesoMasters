using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
    public static CharacterSelectManager instance;
    public string selectedSpriteName; // Changed variable name to avoid conflict
    private Sprite selectedSprite; // Removed duplicate declaration
    public FirebaseAuth auth;
    public DatabaseReference databaseReference;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSelectedSprite(Sprite sprite)
    {
        selectedSprite = sprite; // Assigning the sprite to the class variable
        Debug.Log("Selected");
    }

    public void FetchSpriteName(string userId)
    {
        databaseReference.Child("users").Child(userId).Child("selectedSprite").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failed to fetch sprite name: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    string spriteName = snapshot.Value.ToString();
                    Debug.Log("Fetched sprite name: " + spriteName);
                    selectedSpriteName = spriteName; // Assigning the sprite name to the class variable
                }
                else
                {
                    Debug.Log("No sprite name found for user: " + userId);
                }
            }
        });
    }

    public Sprite GetSelectedSprite()
    {
        return selectedSprite;
    }
}
