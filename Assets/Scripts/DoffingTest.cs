using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoffingTest : MonoBehaviour
{
    public Image[] ItemsSprites;
    
    public Sprite[] OnTrue;

    public GameObject[] ToActivate1;
    public GameObject[] ToActivate2;
    public GameObject[] ToDeactivate1;
    public GameObject[] ToDeactivate2;

    public GameObject NextButtonHider;

    private bool[] currState = { false, false};

    public void CheckItem(int index)
    {
        Debug.Log("----------------------------------");
        Debug.LogFormat("Curr Index = {0}", index);
        if (!currState[index])
        {
            Debug.Log("IF - currState == FALSE");
            if (index == 0)
            {
                Debug.Log("INDEX == 0; Update Sprites");
                ItemsSprites[index].sprite = OnTrue[index];
                currState[index] = true;

                for (int a = 0; a < ToActivate1.Length; a++)
                {
                    ToActivate1[a].SetActive(true);
                }
                for (int b = 0; b < ToDeactivate1.Length; b++)
                {
                    ToDeactivate1[b].SetActive(true);
                }
            }
            else
            {
                if (currState[0]==true)
                {
                    Debug.Log("INDEX == 1; Update Sprites");
                    ItemsSprites[index].sprite = OnTrue[index];
                    currState[index] = true;

                    for (int a = 0; a < ToActivate1.Length; a++)
                    {
                        ToActivate1[a].SetActive(true);
                    }
                    for (int b = 0; b < ToDeactivate1.Length; b++)
                    {
                        ToDeactivate1[b].SetActive(true);
                    }
                }
            }
        }
        
        if (currState[1] == true)
        {
            NextButtonHider.SetActive(false);
        }
    }
}
