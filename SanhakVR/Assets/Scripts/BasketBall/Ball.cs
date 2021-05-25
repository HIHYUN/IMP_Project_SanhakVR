using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Grab, IPuzzle
{
    public Transform ballSpawnPlace;

    private bool isSolved = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("net"))
        {
            print("GoalIn!");
            isSolved = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.tag);
    }


    public bool IsSolved()
    {
        return isSolved;
    }
}
