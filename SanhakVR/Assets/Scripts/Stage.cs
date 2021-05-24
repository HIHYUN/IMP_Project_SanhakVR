using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField]
    private int _stageNum;
    public int stageNum 
    {
        get => _stageNum;
    }

    private bool allSolved = false;

    private List<IPuzzle> _puzzles = new List<IPuzzle>();
    public List<IPuzzle> puzzles
    {
        get => _puzzles;
    }

    public bool Notify()
    {
        foreach (var puzzle in puzzles)
        {
            if (!puzzle.IsSolved())
                return false;
        }
        return true;
    }

    private void Awake()
    {
        StageController.Instance.AddStage(this);
        StageController.Instance.activeStage = this;
    }

    private void Update()
    {
        print(allSolved);
        if (!allSolved)
            allSolved = Notify();

        else
        {
            StageController.Instance.MoveNext();
        }
    }

    public void addPuzzle(IPuzzle puzzle)
    {
        puzzles.Add(puzzle);
    }
}
