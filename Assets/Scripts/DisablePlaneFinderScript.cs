using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlaneFinderScript : MonoBehaviour
{
    public GameObject planeVis;

    public void DisablePlaneVis()
    {
	// planeVis.SetActive(false);
	planeVis.GetComponent<SurfaceVisualizer>().enabled = false;
    }

}
