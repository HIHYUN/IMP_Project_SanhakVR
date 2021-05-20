using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using DG.Tweening;

public class TriggerCubeAnimation : MonoBehaviour
{
 
    private Sequence AlertMotion;

    private void Start() 
    {
        AlertMotion = DOTween.Sequence();

        AlertMotion.SetAutoKill(false)
                    .Append(transform.DOScale(10, 1f).From(7, true))
                    .Append(transform.DOScale(10,1f).From())
                    .SetLoops(-1, LoopType.Restart);
    }
    private void OnEnable() 
    {
        AlertMotion.Restart();
    }
    private void Update() 
    {
        if(this.GetComponent<Renderer>().material.color.a == 1)
        {
            AlertMotion.Pause();
            transform.Rotate(Vector3.one * 45 * Time.deltaTime, Space.World);
        }
    }
}
