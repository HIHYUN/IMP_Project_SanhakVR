using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Grab : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Rigidbody rigidbody 
    {
        get => _rigidbody;
    }

    public bool isGrab;

    private XRGrabInteractable _interactable;
    public XRGrabInteractable interactable
    {
        get => _interactable;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _interactable = GetComponent<XRGrabInteractable>();
    }
}
