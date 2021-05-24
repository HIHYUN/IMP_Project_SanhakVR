using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Grab
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("net"))
        {
            print("GoalIn!");
        }
    }
}
