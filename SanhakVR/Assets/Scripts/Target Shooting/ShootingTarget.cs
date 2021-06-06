using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTarget : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        other.gameObject.GetComponent<TargetController>().count++;
    }
}
