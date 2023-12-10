using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using System;

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

    void Start()
    {
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

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = FirebaseAuth.DefaultInstance;
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
        SceneManager.LoadScene(sceneToLoad);
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

            if (User.IsEmailVerified)
            {
                SceneManager.LoadScene(sceneToLoad);
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
    }

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
                    UserProfile profile = new UserProfile { DisplayName = _age };
                    Task profileTask = User.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(() => profileTask.IsCompleted);

                    if (profileTask.Exception != null)
                    {
                        HandleAuthError(profileTask.Exception);
                    }
                    else
                    {
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

        string message = "Authentication Failed!";
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
                // Add more cases as needed
        }

        if (warningLoginText != null)
        {
            warningLoginText.text = message;
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
