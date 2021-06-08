using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClear : MonoBehaviour, IPuzzle
{
    public int clearCount;

    private bool isSolved = false;
    private Stage stage;

    private void Start()
    {
        stage = StageController.Instance.activeStage;
        stage.addPuzzle(this);
    }

    public void CheckSolved()
    {
        if (clearCount == 3)
        {
            isSolved = true;
        }
    }

    public bool IsSolved()
    {
        return isSolved;
    }


    // Update is called once per frame
    void Update()
    {
        CheckSolved();
    }
}
