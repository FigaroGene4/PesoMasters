using Firebase;
using Firebase.Database;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DataEnterAge : MonoBehaviour
{
    public Slider ageSlider;
    public TMP_Text ageText;
    private string userAge;
    private DatabaseReference dbReference;

    void Start()
    {
        userAge = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

        ageSlider.onValueChanged.AddListener(delegate { UpdateAge(); });

        UpdateAge();
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
        dbReference.Child("UserAge").Child(userAge).SetValueAsync(age);
    }
}
