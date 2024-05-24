using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;

public class SelectSprite : MonoBehaviour
{
    public Sprite clickedSprite; // Assign the clicked sprite in the Unity Editor
    public Sprite originalSprite;
    public SpriteRenderer spriteRenderer;
    public FirebaseAuth auth;
    public DatabaseReference databaseReference;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite; // Store the original sprite
        auth = FirebaseAuth.DefaultInstance;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
   
    }

    public void OnMouseDown()
    {
        Debug.Log("Sprite clicked!");

        // Reset all sprites to original state
        ResetAllSprites();

        // Set the selected sprite to the clicked sprite
        spriteRenderer.sprite = clickedSprite;

        // Set the selected sprite to the CharacterSelectManager
        CharacterSelectManager.instance.SetSelectedSprite(originalSprite);

        // Save the sprite name under user's UID
        string userId = auth.CurrentUser.UserId;
        SaveSpriteName(userId, originalSprite.name);
    }

    public void ResetAllSprites()
    {
        // Find all sprite GameObjects in the scene
        GameObject[] sprites = GameObject.FindGameObjectsWithTag("Sprite");

        // Reset each sprite to its original state
        foreach (GameObject spriteObject in sprites)
        {
            SelectSprite selectSprite = spriteObject.GetComponent<SelectSprite>();
            if (selectSprite != null)
            {
                spriteObject.GetComponent<SpriteRenderer>().sprite = selectSprite.originalSprite;
            }
        }
    }

    public void SaveSpriteName(string userId, string spriteName)
    {
        // Save sprite name under user's UID in Firebase Database
        databaseReference.Child("users").Child(userId).Child("selectedSprite").SetValueAsync(spriteName)
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogError("Failed to save sprite name: " + task.Exception);
                }
                else if (task.IsCompleted)
                {
                    Debug.Log("Sprite name saved successfully!");
                }
            });
    }

    
}
