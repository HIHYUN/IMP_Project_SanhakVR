using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Grab, IPuzzle
{
    public Transform ballSpawnPlace;

    [SerializeField]
    private bool isSolved = false;
    private Stage stage;

    private void Start()
    {
        stage = StageController.Instance.activeStage;
        stage.addPuzzle(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("net"))
        {
            isSolved = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        print(other.tag);
    }


    public void CheckSolved()
    {
       
    }

    public bool IsSolved()
    {
        return isSolved;
    }
}
