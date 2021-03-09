using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSwitchOnCollision : MonoBehaviour
{
    public GameObject[] ToEnable;
    public GameObject[] ToDisable;
    public string ColliderName;
    
    /*
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == ColliderName)
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Collided");
            Destroy(gameObject);
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
    */

    void OnTriggerEnter(Collider collision) 
    {    
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == ColliderName)
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Collided");
            Destroy(gameObject);
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
