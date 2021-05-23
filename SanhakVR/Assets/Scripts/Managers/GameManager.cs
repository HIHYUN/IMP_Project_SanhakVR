using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum StageState
    { 
        unsolved, 
        allSolved
    }

    private StageState _stageState;
    public StageState stageState
    {
        get => _stageState;
        set => _stageState = value;
    }

    
}
