using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerCubeAnimation : MonoBehaviour
{
 
    private Sequence AlertMotion;
    private string matchtag;
    private void Start() 
    {
        
        switch(this.name)
        {
            case "Red Sign":
                matchtag = "Red Cube";
                break;
            case "Yellow Sign":
                matchtag = "Yellow Cube";
                break;
            case "Orange Sign":
                matchtag = "Orange Cube";
                break;
            case "Blue Sign":
                matchtag = "Blue Cube";
                break;
            default:
                break;
        }

        AlertMotion = DOTween.Sequence();

        AlertMotion.SetAutoKill(false)
                    .Append(transform.DOScale(25, 1f).From(20, true))
                    .Append(transform.DOScale(25,1f).From())
                    .SetLoops(-1, LoopType.Restart);
        
    }
    private void OnEnable() {
        AlertMotion.Restart();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == matchtag)
        {
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }
    
}
