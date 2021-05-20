using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : Grab
{
    [SerializeField]
    private bool isStand;

    [SerializeField]
    private bool isGround;

    [SerializeField]
    private bool beenRotate;

    [SerializeField]
    private Quaternion targetRotation;

    private void Start()
    {
        interactable.
            onSelectEntered.
            AddListener(call => isGrab = true);
        
        interactable.
            onSelectCanceled.
            AddListener(call => isGrab = true);
    }

    private void Update()
    {
        CheckIsStanding();

        if (isGrab)
            targetRotation = transform.rotation;
    }

    private void CheckIsStanding()
    {
        Vector3 rotation = transform.rotation.eulerAngles;

        print(rotation);

        isStand = Mathf.Abs(rotation.x) < 1 && Mathf.Abs(rotation.z) < 1;
    }

    private void CheckHasBeenRotated()
    { 
        
    }
}
