using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DartScore : MonoBehaviour, IPuzzle
{
    public int score;
    public GameObject stuckdarts;

    [SerializeField]
    private bool isSolved = false;

    public void CheckSolved()
    {
        if (stuckdarts.transform.childCount == 4)
        {
            isSolved = true;
        }
    }

    public bool IsSolved()
    {
        return isSolved;
    }

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckSolved();
    }

}
