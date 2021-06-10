using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class MatchToTrigger : MonoBehaviour
{
    private XRGrabInteractable interactable;
    public XRBaseController controller;
    private string matchtag;

    private void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();

        switch(this.name)
        {
            case "Red Cube":
                matchtag = "Red Sign";
                break;
            case "Yellow Cube":
                matchtag = "Yellow Sign";
                break;
            case "Orange Cube":
                matchtag = "Orange Sign";
                break;
            case "Blue Cube":
                matchtag = "Blue Sign";
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == matchtag)
        {
            Color color = other.gameObject.transform.GetComponent<Renderer>().material.color;
            color.a = 1;
            other.gameObject.GetComponent<Renderer>().material.color = color;
            GameObject.Find("Sign").GetComponent<TriggerCubeManager>().score++;

            gameObject.SetActive(false);
        }
    }

    public void SetController(XRBaseController controller)
    {
        this.controller = controller;
    }
}
