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
        print(collision.collider.tag);

        if (collision.collider.tag == "FlipTarget")
        {
            bottle.isGround = true;
        }
    }

    private void OnCollisionExit() 
    {   
        bottle.isGround = false;
    }
}
