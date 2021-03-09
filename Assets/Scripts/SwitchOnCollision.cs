using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnCollision : MonoBehaviour
{
    public GameObject ToEnable;
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Switch")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Collided");
            Destroy(gameObject);
            ToEnable.SetActive(true);
        }
    }
}
