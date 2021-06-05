using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    public bool bluematch;
    public bool redmatch;
    public bool yellowmatch;

    public GameObject clear;
    public GameObject key;

    // Update is called once per frame
    void Update()
    {
        if(bluematch && redmatch && yellowmatch)
        {
            clear.SetActive(true);
            key.SetActive(true);
        }
    }
}
