using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchedMotion : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Rigidbody>() == null)
        {
            transform.Rotate(Vector3.one * 45 * Time.deltaTime, Space.World);
        }
    }
}
