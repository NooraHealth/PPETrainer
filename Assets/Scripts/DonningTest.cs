using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonningTest : MonoBehaviour
{
    public Image[] ItemsSprites;
    
    public Sprite[] OnFalse;
    public Sprite[] OnTrue;
    public Sprite[] NeutralSprites;

    public GameObject[] ToActivate;

    public GameObject NextButton;

    private bool[] currState = { false, false, false, false, false, false, false };

    public void CheckItem(int num)
    {
        int index = num - 1;

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

                ToActivate[index].SetActive(false);

                StartCoroutine(WaitForSec(3F));

                ToActivate[num].SetActive(true);

                for (int k = index + 1; k < ItemsSprites.Length; k++)
                {
                    Debug.Log("Reset False ANS");
                    ItemsSprites[k].sprite = NeutralSprites[k];
                }
            }
            else
            {
                bool flag = true;
                Debug.Log("Index != 0; Else Part");
                for (int j = 0; j < index; j++)
                {
                    if (!currState[j])
                    {
                        ItemsSprites[index].sprite = OnFalse[index];

                        Debug.Log("Update to FalseSprite && False flag");
                        StartCoroutine(WaitForSec(1F));
                        ItemsSprites[index].sprite = NeutralSprites[index];
                        flag = false;
                    }
                }

                if (flag)
                {
                    Debug.Log("ALL PREVIOUS ANS are CORRECT, set CURRENT to TRUE");
                    ItemsSprites[index].sprite = OnTrue[index];
                    currState[index] = true;

                    ToActivate[1].SetActive(false);
                    ToActivate[2].SetActive(true);
                    ToActivate[num + 1].SetActive(true);

                    for (int k = index + 1; k < ItemsSprites.Length; k++)
                    {
                        Debug.Log("Reset False ANS");
                        ItemsSprites[k].sprite = NeutralSprites[k];
                    }
                }
            }
        }
        
        if (currState[6] == true)
        {
            NextButton.SetActive(true);
        }
    }

    IEnumerator WaitForSec(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
