using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetController : MonoBehaviour
{
    public GameObject targetclear;
    public int count = 0;
    
    private void Update() 
    {
        if(count > 10)
        {
            transform.DORotate(new Vector3(-90,0,0), 3f, RotateMode.WorldAxisAdd);
            count = 0;
            targetclear.GetComponent<TargetClear>().clearCount++;
        }    
    }


}
