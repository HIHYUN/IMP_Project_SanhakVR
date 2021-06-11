using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetController : MonoBehaviour
{
    public int count = 0;
    private TargetClear targetClear;

    private void Awake()
    {
        targetClear = FindObjectOfType<TargetClear>();
    }


    private void Update() 
    {
        if (count < 0)
            return;

        if (count > 10)
        {
            targetClear.clearCount += 1;
            transform.DORotate(new Vector3(-90, 0, 0), 3f, RotateMode.WorldAxisAdd);
            count = -1;
        }
    }


}
