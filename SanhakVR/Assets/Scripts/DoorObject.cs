using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : MonoBehaviour
{
    public bool isOpen = false;

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.name);

        if (collision.collider.CompareTag("Key"))
        {
            isOpen = true;
        }
    }
}
