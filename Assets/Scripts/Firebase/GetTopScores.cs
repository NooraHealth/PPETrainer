using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Unity.Editor;
using UnityEngine.UI;

public class GetTopScores : MonoBehaviour
{

    public Text[] PlayerNames;
    public Text[] ScoreValues;

    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://gocoronanoorahealth.firebaseio.com/");

        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        // Save Player Data
        writeNewUser(PlayerPrefs.GetString("U_ID"), PlayerPrefs.GetString("U_NAME"), PlayerPrefs.GetString("U_EMAIL"), PlayerPrefs.GetInt("U_SCORE"));

        // Get top Scores
        GetScores();
    }

    private void writeNewUser(string userId, string name, string email, int score)
    {
        DatabaseReference mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        UserArgs user = new UserArgs(name, email, score);
        string json = JsonUtility.ToJson(user);

        mDatabaseRef.Child("users").Child(userId).SetRawJsonValueAsync(json);
    }

    public void GetScores()
    {
        FirebaseDatabase.DefaultInstance
        .GetReference("users").OrderByChild("PlayerScore").LimitToLast(10)
        .ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        DataSnapshot snap = args.Snapshot;

        int index = 9;
        foreach (var userId in snap.Children)
        {

            PlayerNames[index].text = "" + userId.Child("PlayerName").Value.ToString();
            ScoreValues[index].text = "" + userId.Child("PlayerScore").Value.ToString();

            index--;
        }
    }
}