using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetController : MonoBehaviour, IPuzzle
{
    public int count = 0;
    private Stage stage;
    private bool isSolved = false;



    private void Start()
    {
        stage = StageController.Instance.activeStage;
        stage.addPuzzle(this);
    }

    public void CheckSolved()
    {
        if (count > 10)
        {
            transform.DORotate(new Vector3(-90, 0, 0), 3f, RotateMode.WorldAxisAdd);
            count = 0;
        }
    }

    public bool IsSolved()
    {
        return isSolved;
    }

    private void Update() 
    {
        
    }


}
