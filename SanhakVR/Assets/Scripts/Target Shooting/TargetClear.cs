using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClear : MonoBehaviour
{
    public int clearCount;
    public GameObject clearText;
    
    // Update is called once per frame
    void Update()
    {
        if(clearCount ==3)
        {
            clearText.SetActive(true);
        }
    }
}
