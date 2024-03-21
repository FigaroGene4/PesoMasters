using Firebase.Auth;
using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class dataSaveDB : MonoBehaviour
{

    public CoinsBar coinsBar;
    public StarBar starBar;
    public dataUseDB dataUseDB;
    public int coins = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }


    public void addStar()
    {
        int starsToAdd = starBar.current;
        try
        {
            // Get current user
            FirebaseAuth auth = FirebaseAuth.DefaultInstance;
            FirebaseUser user = auth.CurrentUser;

            // Check if user is authenticated
            if (user != null)
            {
                DatabaseReference userRef = FirebaseDatabase.DefaultInstance.GetReference("users").Child(user.UserId).Child("star");

                // Retrieve current stars from the database
                userRef.GetValueAsync().ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        Debug.LogError("Failed to retrieve current stars: " + task.Exception);
                        return;
                    }

                    DataSnapshot snapshot = task.Result;
                    int currentStars = snapshot.Exists ? Convert.ToInt32(snapshot.Value) : 0;

                    // Calculate total stars
                    int totalStars = currentStars + starsToAdd;

                    // Update stars in the database
                    userRef.SetValueAsync(totalStars).ContinueWith(updateTask =>
                    {
                        if (updateTask.IsCompleted)
                        {
                            Debug.Log("Stars updated successfully.");
                        }
                        else if (updateTask.IsFaulted)
                        {
                            Debug.LogError("Failed to update stars: " + updateTask.Exception);
                        }
                    });
                });
            }
            else
            {
                Debug.LogError("User is not authenticated.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }



    public void addCoins()
    {
        int coinsToAdd = coinsBar.current;
        try
        {
            // Get current user
            FirebaseAuth auth = FirebaseAuth.DefaultInstance;
            FirebaseUser user = auth.CurrentUser;

            // Check if user is authenticated
            if (user != null)
            {
                DatabaseReference userRef = FirebaseDatabase.DefaultInstance.GetReference("users").Child(user.UserId).Child("coins");

                // Retrieve current coins from the database
                userRef.GetValueAsync().ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        Debug.LogError("Failed to retrieve current coins: " + task.Exception);
                        return;
                    }

                    DataSnapshot snapshot = task.Result;
                    int currentCoins = snapshot.Exists ? Convert.ToInt32(snapshot.Value) : 0;

                    // Calculate total coins
                    int totalCoins = currentCoins + coinsToAdd;

                    // Update coins in the database
                    userRef.SetValueAsync(totalCoins).ContinueWith(updateTask =>
                    {
                        if (updateTask.IsCompleted)
                        {
                            Debug.Log("Coins updated successfully.");
                        }
                        else if (updateTask.IsFaulted)
                        {
                            Debug.LogError("Failed to update coins: " + updateTask.Exception);
                        }
                    });
                });
            }
            else
            {
                Debug.LogError("User is not authenticated.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }





    public void addStarLvl1Stage1()
    {
        int starsToAdd = starBar.current;
        try
        {
            // Get current user
            FirebaseAuth auth = FirebaseAuth.DefaultInstance;
            FirebaseUser user = auth.CurrentUser;

            // Check if user is authenticated
            if (user != null)
            {
                DatabaseReference userRef = FirebaseDatabase.DefaultInstance.GetReference("users").Child(user.UserId).Child("addStarLvl1Stage1");

                // Retrieve current stars from the database
                userRef.GetValueAsync().ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        Debug.LogError("Failed to retrieve current stars: " + task.Exception);
                        return;
                    }

                    DataSnapshot snapshot = task.Result;
                    int currentStars = snapshot.Exists ? Convert.ToInt32(snapshot.Value) : 0;

                    // Replace the stored value with the new value
                    userRef.SetValueAsync(starsToAdd).ContinueWith(updateTask =>
                    {
                        if (updateTask.IsCompleted)
                        {
                            Debug.Log("Stars updated successfully.");
                        }
                        else if (updateTask.IsFaulted)
                        {
                            Debug.LogError("Failed to update stars: " + updateTask.Exception);
                        }
                    });
                });
            }
            else
            {
                Debug.LogError("User is not authenticated.");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }


}