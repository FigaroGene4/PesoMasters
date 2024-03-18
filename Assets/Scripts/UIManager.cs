using System.Collections;
using System.Collections.Generic;
using TMPro;
/*using UnityEditor.VersionControl;*/
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //Screen object variables
    public GameObject loginUI;
    public GameObject registerUI;
    public GameObject EmailVerification;
    public TMP_Text emailverificationText;
    //public TMP_Text warningLoginText;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        loginUI.SetActive(true);
        registerUI.SetActive(false);
    }
    public void RegisterScreen() // Regester button
    {
        loginUI.SetActive(false);
        registerUI.SetActive(true);
    }
    public void ShowVerificationResponse(bool isEmailSent, string emailID, string errorMessage)
    {
        EmailVerification.SetActive(true);

        if (isEmailSent)
        {
            Debug.Log($"Verification link has been sent to email {emailID}");
            emailverificationText.text = ($"Verification link has been sent to email {emailID}");
        }
        else
        {
            Debug.Log($"Couldn't send link to email {errorMessage}");
            emailverificationText.text = ($"Couldn't send  link to email {errorMessage}");
        }
    }

}
