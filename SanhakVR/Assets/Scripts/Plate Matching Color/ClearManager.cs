using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour, IPuzzle
{
    public GameObject clear;

    private Stage stage;
    private bool isSolved = false;

    public DoorObject door;

    public void CheckSolved()
    {
        if (door.isOpen)
            isSolved = true;
    }

    public bool IsSolved()
    {
        return isSolved;
    }

    private void Start()
    {
        stage = StageController.Instance.activeStage;
        stage.addPuzzle(this);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        CheckSolved();
    }
}
