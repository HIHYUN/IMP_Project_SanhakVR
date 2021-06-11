using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCollision : MonoBehaviour
{
    private string tagName;
    private GameObject platemanage;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        tagName = this.tag;
        platemanage = transform.parent.gameObject;

        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other) 
    {        
        if(other.gameObject.CompareTag("Blue Cube") && (tagName == "Blue Sign"))
        {
            platemanage.GetComponent<PlateController>().bluematch = true;
            other.rigidbody.isKinematic = true;
            rb.isKinematic = true;
        }
        else if(other.gameObject.CompareTag("Red Cube") && (tagName == "Red Sign"))
        {
            platemanage.GetComponent<PlateController>().redmatch = true;
            other.rigidbody.isKinematic = true;
            rb.isKinematic = true;
        }   
        else if(other.gameObject.CompareTag("Yellow Cube") && (tagName == "Yellow Sign"))
        {
            platemanage.GetComponent<PlateController>().yellowmatch = true;
            other.rigidbody.isKinematic = true;
            rb.isKinematic = true;
        }
    }
}
