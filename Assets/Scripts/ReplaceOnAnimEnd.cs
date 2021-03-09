using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceOnAnimEnd : MonoBehaviour
{
    // Gameobjects to Enable after Animation Ends
    public GameObject[] ToEnable;
    // Gameobjects to Disable after Animation Ends
    public GameObject[] ToDisable;


    // Step 1 - On Glove Animation Ends
    public void GloveAnimEnd(string message)
    {
        Debug.Log("GloveAnimEnd Called!!!");
        if (message.Equals("AnimEnd"))
        {
            Debug.Log("Inside Message check!!");
            for (int i = 0; i < ToEnable.Length; i++)
            {
                ToEnable[i].SetActive(true);
            }
            for (int i = 0; i < ToDisable.Length; i++)
            {
                ToDisable[i].SetActive(false);
            }
        }
    }

    // Step 2 - On Coverall Animation Ends
    public void CoverallAnimEnd(string message)
    {
        Debug.Log("CoverallAnimEnd Called!!!");
        if (message.Equals("AnimEnd"))
        {
            Debug.Log("Inside Message check!!");
            for (int i = 0; i < ToEnable.Length; i++)
            {
                ToEnable[i].SetActive(true);
            }
            for (int i = 0; i < ToDisable.Length; i++)
            {
                ToDisable[i].SetActive(false);
            }
        }
    }

    // Step 3 - On Shoe Cover Animation Ends
    public void ShoeAnimEnd(string message)
    {
        Debug.Log("ShoeAnimEnd Called!!!");
        if (message.Equals("AnimEnd"))
        {
            Debug.Log("Inside Message check!!");
            for (int i = 0; i < ToEnable.Length; i++)
            {
                ToEnable[i].SetActive(true);
            }
            for (int i = 0; i < ToDisable.Length; i++)
            {
                ToDisable[i].SetActive(false);
            }
        }
    }

    // Step 4 - On N95 Mask Animation Ends
    public void MaskAnimEnd(string message)
    {
        Debug.Log("MaskAnimEnd Called!!!");
        if (message.Equals("AnimEnd"))
        {
            Debug.Log("Inside Message check!!");
            for (int i = 0; i < ToEnable.Length; i++)
            {
                ToEnable[i].SetActive(true);
            }
            for (int i = 0; i < ToDisable.Length; i++)
            {
                ToDisable[i].SetActive(false);
            }
        }
    }

    // Step 5 - On Coverall Hood Animation Ends
    public void HoodAnimEnd(string message)
    {
        Debug.Log("HoodAnimEnd Called!!!");
        if (message.Equals("AnimEnd"))
        {
            Debug.Log("Inside Message check!!");
            for (int i = 0; i < ToEnable.Length; i++)
            {
                ToEnable[i].SetActive(true);
            }
            for (int i = 0; i < ToDisable.Length; i++)
            {
                ToDisable[i].SetActive(false);
            }
        }
    }

    // Step 6 - On Face Shield Animation Ends
    public void FaceShieldAnimEnd(string message)
    {
        Debug.Log("FaceShieldAnimEnd Called!!!");
        if (message.Equals("AnimEnd"))
        {
            Debug.Log("Inside Message check!!");
            for (int i = 0; i < ToEnable.Length; i++)
            {
                ToEnable[i].SetActive(true);
            }
            for (int i = 0; i < ToDisable.Length; i++)
            {
                ToDisable[i].SetActive(false);
            }
        }
    }

    // Step 7 - On Bigger Glove Animation Ends
    public void BiggerGloveAnimEnd(string message)
    {
        Debug.Log("BiggerGloveAnimEnd Called!!!");
        if (message.Equals("AnimEnd"))
        {
            Debug.Log("Inside Message check!!");
            for (int i = 0; i < ToEnable.Length; i++)
            {
                ToEnable[i].SetActive(true);
            }
            for (int i = 0; i < ToDisable.Length; i++)
            {
                ToDisable[i].SetActive(false);
            }
        }
    }
}
