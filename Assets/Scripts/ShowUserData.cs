using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUserData : MonoBehaviour
{
    public Text UserName;

    void Start()
    {
        string name = PlayerPrefs.GetString("U_NAME");
        UserName.text = "Hi <b>" + name + "</b>!";
        Debug.Log(name);
    }
}
