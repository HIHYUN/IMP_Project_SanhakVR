using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour, IPuzzle
{
    public GameObject clear;

    private Stage stage;
    private bool isSolved = false;

    public void CheckSolved()
    {
        
    }

    public bool IsSolved()
    {
        return isSolved;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Key"))
        {
            // Game Clear
            clear.SetActive(true);
            Destroy(other.gameObject);
            // Application.Quit();
        }    
    }

    private void Start()
    {
        stage = StageController.Instance.activeStage;
        stage.addPuzzle(this);
    }
}
