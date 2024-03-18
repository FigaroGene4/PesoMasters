using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class dataUseDB : MonoBehaviour
{
    // Start is called before the first frame update


    public TextMeshProUGUI textCoins;
    public TextMeshProUGUI textStar;
    public dataSaveDB dataSaveDB;
    


    public void Start()
    {
        getUserCoins();
        getUserStar();
    }

    public void Update()
    {
        
    }

    public async Task<int> getUserCoins()
    {
        int coinsToAdd = 0;

        try
        {
            Firebase.Auth.FirebaseAuth auth;
            Firebase.Auth.FirebaseUser User;

            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            User = auth.CurrentUser;

            Firebase.Database.DatabaseReference dbReference = Firebase.Database.FirebaseDatabase.DefaultInstance.RootReference;
            var dataSnapshot = await dbReference.Child("users").Child(User.UserId).GetValueAsync();

            if (dataSnapshot.Exists)
            {
                IDictionary dictUser = (IDictionary)dataSnapshot.Value;
                coinsToAdd = Convert.ToInt32(dictUser["coins"]);
            }
        }
        catch (Exception e)
        {
            Debug.Log("An error occurred: " + e.Message);
        }

        textCoins.SetText(coinsToAdd.ToString());
        return coinsToAdd;
        
    }

   


    public async Task<int> getUserStar()
    {
        int userStar = 0;

        try
        {
            Firebase.Auth.FirebaseAuth auth;
            Firebase.Auth.FirebaseUser User;

            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            User = auth.CurrentUser;

            Firebase.Database.DatabaseReference dbReference = Firebase.Database.FirebaseDatabase.DefaultInstance.RootReference;
            var dataSnapshot = await dbReference.Child("users").Child(User.UserId).GetValueAsync();

            if (dataSnapshot.Exists)
            {
                IDictionary dictUser = (IDictionary)dataSnapshot.Value;
                userStar = Convert.ToInt32(dictUser["star"]);
            }
        }
        catch (Exception e)
        {
            Debug.Log("An error occurred: " + e.Message);
        }


        textStar.SetText(userStar.ToString());
        return userStar;


    }
}
