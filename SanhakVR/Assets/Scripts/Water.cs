using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Bottle bottle;

    private void Awake()
    {
        bottle = transform.GetSibling(0).GetComponent<Bottle>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            bottle.isGround = true;
        }
    }

    private void OnCollisionExit() 
    {
        bottle.isGround = false;
    }
}
