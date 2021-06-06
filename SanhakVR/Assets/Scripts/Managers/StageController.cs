using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : Singleton<StageController>
{
    [SerializeField]
    private List<Stage> _stages = new List<Stage>();
    public List<Stage> stages
    {
        get => _stages;
    }

    [SerializeField]
    private List<string> _stageNames = new List<string>();
    public List<string> stageNames
    {
        get => _stageNames;
    }

    [SerializeField]
    private Stage _activeStage;
    public Stage activeStage
    {
        get => _activeStage;
        set
        {
            if (value != null)
                _activeStage = value;
        }
    }

    public enum StageState
    { 
        Stage1, Stage2, Stage3
    }

    public StageState stageState;

    public bool isOnLoad = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void MoveNext()
    {
        SceneManager.LoadScene((int)stageState+1);
    }

    public void AddStage(Stage stage)
    {
        if (stage != null)
            stages.Add(stage);
    }

    public void RemoveStage(Stage stage)
    {
        stages.Remove(stage);
    }

    private int FindActiveIndex()
    {
        return stages.FindIndex(stage => stage == activeStage);
    }
}
