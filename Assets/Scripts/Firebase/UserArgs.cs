using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class UserArgs : MonoBehaviour
{
    public string PlayerName;
    public string PlayerEmail;
    public int PlayerScore = 0;

    public UserArgs()
    {
    }

    public UserArgs(string name, string email, int score)
    {
        this.PlayerName = name;
        this.PlayerEmail = email;
        this.PlayerScore = score;
    }
}
