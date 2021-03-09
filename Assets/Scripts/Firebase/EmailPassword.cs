using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Security.Cryptography;
using System.Text;

public class EmailPassword : MonoBehaviour
{

    public GameObject signUpUI;
    public GameObject logInUI;

    private FirebaseAuth auth;
    public InputField NameInput, UNInput1, UNInput2, PInput1, PInput2;
    private static string UserNameInput, PasswordInput;
    public Button SignupButton;
    public Button LoginButton;
    public Text ErrorText;
    public Text LoginResultText;

    internal static readonly char[] chars =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();


    // Start Method
    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        //Just an example to save typing in the login form
        // PlayerPrefs.SetString("U_PASS", "GoCorona");
        
        var u_name = PlayerPrefs.GetString("U_NAME");

        var u_email = PlayerPrefs.GetString("U_EMAIL");
        var u_pass = PlayerPrefs.GetString("U_PASS");

        if (string.IsNullOrEmpty(u_email))
        {
            signUpUI.SetActive(true);
            logInUI.SetActive(false);
        }
        else
        {
            signUpUI.SetActive(false);
            logInUI.SetActive(true);
        }


        if (!string.IsNullOrEmpty(u_email) || !string.IsNullOrEmpty(u_pass))
        {
            Debug.Log("UserNameInput is = " + UNInput2.text);
            Debug.Log("PassInput is = " + PInput2.text);

            Debug.Log("Current Email is = " + u_email);
            Debug.Log("Current Pass is = " + u_pass);

            UNInput2.text = u_email;
            PInput2.text = u_pass;
        }

        if(signUpUI.activeSelf)
        {
            Debug.Log("1. SignUpUI Active");
            UserNameInput = UNInput1.text;
            PasswordInput = PInput1.text;
        }
        else
        {
            Debug.Log("2. SignInUI Active");
            UserNameInput = UNInput2.text;
            PasswordInput = PInput2.text;
        }

        // If Email is null, Assign a new Email
        // if(u_email== "")
        // {
        //     System.Random size = new System.Random();
        //     string randomEmail = GetUniqueKey(size.Next(8, 16)) + "@gocorona.com";
        //     PlayerPrefs.SetString("U_EMAIL", randomEmail);
        //     Debug.Log("New email created: " + randomEmail);
        // }

        // u_email = PlayerPrefs.GetString("U_EMAIL");

        // var u_pass = PlayerPrefs.GetString("U_PASS");

        // if (u_email != null && u_pass != null && u_name != null && u_name != " ")
        // {
        //     NameInput.text = u_name;
        //     UserNameInput = u_email;
        //     PasswordInput = u_pass;

        //     // Login User Automatically
        //     Login(u_email, u_pass);
        // }

        SignupButton.onClick.AddListener(() => Signup(UNInput1.text, PInput1.text, NameInput.text));
        LoginButton.onClick.AddListener(() => Login(UNInput2.text, PInput2.text));
    }

    // Sign Up user in Database
    public void Signup(string email, string password, string name)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(name))
        {
            //Error handling
            return;
        }

        PlayerPrefs.SetString("U_EMAIL", email);
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
                return;
            }

            FirebaseUser newUser = task.Result; // Firebase user has been created.
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            // UpdateErrorMessage("Signup Success");
            // Debug.Log("--------------Creds------------------ \n" + PlayerPrefs.GetString("U_EMAIL") + "  " + PlayerPrefs.GetString("U_PASS") + "  " + PlayerPrefs.GetString("U_NAME") + "  " + PlayerPrefs.GetString("U_ID"));

            PlayerPrefs.SetString("U_EMAIL", newUser != null ? newUser.Email : "Unknown");
            PlayerPrefs.SetString("U_PASS", newUser != null ? password : "Unknown");
            PlayerPrefs.SetString("U_NAME", newUser != null ? newUser.DisplayName : "Unknown");
            PlayerPrefs.SetString("U_ID", newUser != null ? newUser.UserId : "Unknown");

            Debug.Log("Data saved!!!");

            //Set Default Score to 0
            PlayerPrefs.SetInt("U_SCORE", 0);
            // Set How to Play panel active (First time User)
            PlayerPrefs.SetInt("U_TUTORIAL", 1);


            Debug.Log("--------------Creds------------------ \n" + PlayerPrefs.GetString("U_EMAIL") + "  " + PlayerPrefs.GetString("U_PASS") + "  " + PlayerPrefs.GetString("U_NAME") + "  " + PlayerPrefs.GetString("U_ID"));
            
            // Update User's Name
            UpdateName();

            // LogIn User
            // Login(PlayerPrefs.GetString("U_EMAIL"), PlayerPrefs.GetString("U_PASS"));
            signUpUI.SetActive(false);
            logInUI.SetActive(true);
        });
    }

    // Update User's Name in Database
    public void UpdateName()
    {
        //Update User Name

        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                DisplayName = NameInput.text,
                PhotoUrl = new System.Uri("https://example.com/jane-q-user/profile.jpg"),
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");

            });
        }
    }

    // Update Error Message
    private void UpdateErrorMessage(string message)
    {
        ErrorText.text = message;
        Invoke("ClearErrorMessage", 3);
    }

    // Clear Error Message
    void ClearErrorMessage()
    {
        ErrorText.text = "";
    }

    // Login User
    public void Login(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0)
                    UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
                return;
            }

            FirebaseUser user = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);

            SceneManager.LoadScene("01 Menu");

            PlayerPrefs.SetString("U_NAME", user != null ? user.DisplayName : "Unknown");
            // SceneManager.LoadScene("LoginResults");
            Debug.Log("-------------Creds------------------- \n" + PlayerPrefs.GetString("U_EMAIL") + "  " + PlayerPrefs.GetString("U_PASS") + "  " + PlayerPrefs.GetString("U_NAME") + "  " + PlayerPrefs.GetString("U_ID"));
            // signUpUI.SetActive(false);
            // loggedInUI.SetActive(true);

            // Log In Message
            var userName = PlayerPrefs.GetString("U_NAME");
            LoginResultText.text = "Hi! " + userName;
            Debug.LogFormat("Successfully signed in as {0}", userName);
        });
    }

    // [Tooltip("'SignUp' or 'SignIn'")]
    public void switchUI(string UIName)
    {
        if(UIName == "SignUp")
        {
            UserNameInput = UNInput1.text;
            PasswordInput = PInput1.text;
            Debug.Log("------- Sign In enabled");
        }
        else
        {
            UserNameInput = UNInput2.text;
            PasswordInput = PInput2.text;
            Debug.Log("------- Sign Up enabled");
        }

    }

    // Generate Random String
    public static string GetUniqueKey(int size)
    {
        byte[] data = new byte[4 * size];
        using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
        {
            crypto.GetBytes(data);
        }
        StringBuilder result = new StringBuilder(size);
        for (int i = 0; i < size; i++)
        {
            var rnd = BitConverter.ToUInt32(data, i * 4);
            var idx = rnd % chars.Length;

            result.Append(chars[idx]);
        }

        return result.ToString();
    }
}