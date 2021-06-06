using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShotDarts : MonoBehaviour
{
    public GameObject stuckparent;
    private void OnTriggerEnter(Collider other) 
    {
        switch(other.gameObject.name)
        {
            case ("10 Point Area"):
                this.transform.position = new Vector3(other.gameObject.transform.position.x,other.gameObject.transform.position.y,stuckparent.transform.position.z);
                other.transform.parent.gameObject.GetComponent<DartScore>().score += 10;
                transform.SetParent(stuckparent.transform);
                break;
            case ("8 Point Area"):
                this.transform.position = new Vector3(other.gameObject.transform.position.x,other.gameObject.transform.position.y,stuckparent.transform.position.z);
                other.transform.parent.gameObject.GetComponent<DartScore>().score += 8;
                transform.SetParent(stuckparent.transform);
                break;
            case ("5 Point Area"):
                this.transform.position = new Vector3(other.gameObject.transform.position.x,other.gameObject.transform.position.y,stuckparent.transform.position.z);
                other.transform.parent.gameObject.GetComponent<DartScore>().score += 5;
                transform.SetParent(stuckparent.transform);
                break;
            case ("3 Point Area"):
                this.transform.position = new Vector3(other.gameObject.transform.position.x,other.gameObject.transform.position.y,stuckparent.transform.position.z);
                other.transform.parent.gameObject.GetComponent<DartScore>().score += 3;
                transform.SetParent(stuckparent.transform);
                break;
            default:
                break;
        }
    }
}
