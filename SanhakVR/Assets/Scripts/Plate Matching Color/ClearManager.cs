using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    public GameObject clear;
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Key"))
        {
            // Game Clear
            clear.SetActive(true);
            Destroy(other.gameObject);
            // Application.Quit();
        }    
    }
}
