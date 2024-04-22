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

public class AuthManager : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;

    //Login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;


    //Register variables
    [Header("Register")]
    public TMP_InputField ageRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;

    public string sceneToLoad = "EnterName";
    string namewew;
    string age;


    void Start()
    {
       


        getDataRealtime();

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
                SetAuthEmulatorEnvironmentVariable();

            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });




    }

    public void getDataRealtime()
    {

    }


    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
        

    }

    public void ClearMessageText()
    {
        if (confirmLoginText != null)
        {
            confirmLoginText.text = "";
        }

        if (warningRegisterText != null)
        {
            warningRegisterText.text = "";
        }
    }


    private void SetAuthEmulatorEnvironmentVariable()
    {
#if UNITY_EDITOR
        // In the Unity Editor, set USE_AUTH_EMULATOR to true during development
        Debug.Log("Setting USE_AUTH_EMULATOR to true for development");
        System.Environment.SetEnvironmentVariable("USE_AUTH_EMULATOR", "true");
#endif
    }

    //Function for the login button
    public void LoginButton()
    {
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }

    //Function for the register button
    public void RegisterButton()
    {
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, ageRegisterField.text));
    }
    public void GuestButton()
    {

        StartCoroutine(GuestLogin());
    }

    public void DoneButton()
    {
        UIManager.instance.LoginScreen();
    }

    private IEnumerator Login(string _email, string _password)
    {
        Task<AuthResult> loginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            HandleAuthError(loginTask.Exception);
        }
        else
        {
            User = loginTask.Result.User;

            if (User != null && User.UserId != null)
            {
                if (User.IsEmailVerified)
                {
                    DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
                    reference.Child("users").Child(User.UserId).GetValueAsync().ContinueWithOnMainThread(task => {
                        if (task.IsFaulted)
                        {
                            // Handle the error...
                            Debug.LogError(task.Exception);
                        }
                        else if (task.IsCompleted)
                        {
                            DataSnapshot snapshot = task.Result;

                            // Check if the snapshot exists and has the required fields
                            if (snapshot.HasChild("name") && snapshot.HasChild("age"))
                            {
                                string namewew = snapshot.Child("name").Value.ToString();
                                string ages = snapshot.Child("age").Value.ToString();

                                Debug.Log("Name: " + namewew);
                                Debug.Log("Age: " + ages);

                                if (namewew != "" && ages != "0")
                                {

                                    Debug.Log(User.UserId);
                                    confirmLoginText.text = "Logged In";
                                    SceneManager.LoadScene("MainMenu");
                                    PlayerPrefs.SetString("userEmail", _email);
                                    Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
                                    warningLoginText.text = "";
                                }

                                else
                                {
                                    Debug.Log(User.UserId);
                                    SceneManager.LoadScene(sceneToLoad);
                                }





                            }

                            else
                            {
                                Debug.LogError("Snapshot does not exist or does not have the required fields");
                            }
                        }
                    });
                }
                else
                {
                    SendEmailForVerification();
                }
            }
            else
            {
                Debug.LogError("User or UserId is null");
            }
        }
    }

    private IEnumerator GuestLogin()

    {

        FirebaseAuth.DefaultInstance.SignOut();
        Task<AuthResult> loginTask = auth.SignInAnonymouslyAsync();
        yield return new WaitUntil(() => loginTask.IsCompleted);

        if (loginTask.Exception != null)
        {
            Debug.LogError("SignInAnonymouslyAsync encountered an error: " + loginTask.Exception);
        }
        else
        {
            FirebaseUser User = loginTask.Result.User;
            Debug.LogFormat("Guest user signed in successfully: {0} ({1})", User.DisplayName, User.UserId);

            DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("users");

            reference.Child(User.UserId).Child("name").SetValueAsync("");
            reference.Child(User.UserId).Child("age").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl1Stage1").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl1Stage2").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl1Stage3").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl2Stage1").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl2Stage2").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl2Stage3").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl3Stage1").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl3Stage2").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl3Stage3").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl4Stage1").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl4Stage2").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl4Stage3").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl5Stage1").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl5Stage2").SetValueAsync(0);
            reference.Child(User.UserId).Child("addStarLvl5Stage3").SetValueAsync(0);
            SceneManager.LoadScene(sceneToLoad);

        }


        
    }


    /*  private IEnumerator Login(string _email, string _password)
      {
          Task<AuthResult> loginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
          yield return new WaitUntil(() => loginTask.IsCompleted);


          if (loginTask.Exception != null)
          {
              HandleAuthError(loginTask.Exception);
          }
          else
          {
              User = loginTask.Result.User;

              DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

              if (User != null && User.UserId != null)
              {
                  reference.Child("users").Child(User.UserId).GetValueAsync().ContinueWith(task => {
                      if (task.IsFaulted)
                      {
                          // Handle the error...
                          Debug.LogError(task.Exception);
                      }
                      else if (task.IsCompleted)
                      {
                          DataSnapshot snapshot = task.Result;

                          // Check if the snapshot exists and has the required fields
                          if (snapshot.Exists && snapshot.HasChild("name") && snapshot.HasChild("age"))
                          {
                              string namewew = snapshot.Child("name").Value.ToString();
                              string ages = snapshot.Child("age").Value.ToString();

                              // Now you can use the name and age
                              Debug.Log("Name: " + namewew);
                              Debug.Log("Age: " + ages);

                              if (User.IsEmailVerified)
                              {
                                  SceneManager.LoadScene("MainMenu");
                                  PlayerPrefs.SetString("userEmail", _email);
                                  Debug.Log("Name: " + namewew);
                                  Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
                                  warningLoginText.text = "";
                                  confirmLoginText.text = "Logged In";
                              }

                              else if (User.IsEmailVerified && namewew == "")
                              {
                                  SceneManager.LoadScene(sceneToLoad);
                                  Debug.Log("name" + namewew);
                                  PlayerPrefs.SetString("userEmail", _email);
                                  Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
                                  warningLoginText.text = "";
                                  confirmLoginText.text = "Logged In";
                              }

                              else
                              {
                                  SendEmailForVerification();
                              }
                          }
                          else
                          {
                              Debug.LogError("Snapshot does not exist or does not have the required fields");
                          }
                      }
                  });
              }
              else
              {
                  Debug.LogError("User or UserId is null");
              }



          }
      }*/


    private IEnumerator Register(string _email, string _password, string _age)
    {
        if (_age == "")
        {
            warningRegisterText.text = "Missing Age";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            warningRegisterText.text = "Password Does Not Match!";
        }
        else
        {
            Task<AuthResult> registerTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            yield return new WaitUntil(() => registerTask.IsCompleted);

            if (registerTask.Exception != null)
            {
                HandleAuthError(registerTask.Exception);
            }
            else
            {
                User = registerTask.Result.User;

                if (User != null)
                {
                    UserProfile profile = new UserProfile { DisplayName = _email };
                    Task profileTask = User.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(() => profileTask.IsCompleted);

                    if (profileTask.Exception != null)
                    {
                        HandleAuthError(profileTask.Exception);
                    }
                    else

                    {

                        DatabaseReference reference = FirebaseDatabase.DefaultInstance.GetReference("users");
                        reference.Child(User.UserId).Child("emailAddress").SetValueAsync(_email);
                        reference.Child(User.UserId).Child("name").SetValueAsync("");
                        reference.Child(User.UserId).Child("age").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl1Stage1").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl1Stage2").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl1Stage3").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl2Stage1").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl2Stage2").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl2Stage3").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl3Stage1").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl3Stage2").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl3Stage3").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl4Stage1").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl4Stage2").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl4Stage3").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl5Stage1").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl5Stage2").SetValueAsync(0);
                        reference.Child(User.UserId).Child("addStarLvl5Stage3").SetValueAsync(0);


                        if (User.IsEmailVerified)
                        {
                            //UIManager.instance.LoginScreen();
                            warningRegisterText.text = "verified";
                        }
                        else
                        {
                            SendEmailForVerification();
                        }
                    }
                }
            }
        }
    }
    
    private void HandleAuthError(AggregateException exception)
    {
        Debug.LogWarning($"Failed with {exception}");
        FirebaseException firebaseEx = exception.GetBaseException() as FirebaseException;
        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

        //string message = "Authentication Failed!";
        // Binago ko kasi di naman alam ng ordinary users yung authentication kaya ayorn
        string message = "Incorrect email or password";
        switch (errorCode)
        {
            case AuthError.MissingEmail:
                message = "Missing Email";
                break;
            case AuthError.MissingPassword:
                message = "Missing Password";
                break;
            case AuthError.WeakPassword:
                message = "Weak Password";
                break;
            case AuthError.EmailAlreadyInUse:
                message = "Email Already In Use";
                Debug.Log("H");
                break;
            case AuthError.WrongPassword:
                message = "Wrong Password";
                break;
            case AuthError.InvalidEmail:
                message = "Invalid Email";
                break;
            case AuthError.UserNotFound:
                message = "Account does not exist";
                break;
            case AuthError.UnverifiedEmail:
                message = "Please verify your email first";
                break;
            case AuthError.InvalidCredential:
                message = "Please enter correct  details";
                break;
          

            default:
                break;
                
                // Add more cases as needed
        }

        if (confirmLoginText != null)
        {
            confirmLoginText.text = message;
        }

        if (warningRegisterText != null)
        {
            warningRegisterText.text = message;
        }
    }

    public void SendEmailForVerification()
    {
        StartCoroutine(SendEmailForVerificationAsync());
    }

    private IEnumerator SendEmailForVerificationAsync()
    {
        if (User != null)
        {
            var sendEmailTask = User.SendEmailVerificationAsync();
            yield return new WaitUntil(() => sendEmailTask.IsCompleted);

            if (sendEmailTask.Exception != null)
            {
                FirebaseException firebaseException = sendEmailTask.Exception.GetBaseException() as FirebaseException;
                AuthError error = (AuthError)firebaseException.ErrorCode;

                string errorMessage = "Unknown Error: Please try again later";

                switch (error)
                {
                    case AuthError.Cancelled:
                        errorMessage = "Email Verification was Cancelled";
                        break;
                    case AuthError.TooManyRequests:
                        errorMessage = "Too Many Requests";
                        break;
                    case AuthError.InvalidRecipientEmail:
                        errorMessage = "The email you entered is Invalid";
                        break;
                }

                UIManager.instance.ShowVerificationResponse(false, User.Email, errorMessage);
            }
            else
            {
                // Email verification sent successfully
                // You can provide feedback to the user if needed
                UIManager.instance.ShowVerificationResponse(true, User.Email, null);
            }
        }
    }
}