using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : Singleton<StageController>
{
    [SerializeField]
    private List<Stage> _stages = new List<Stage>();
    public List<Stage> stages
    {
        get => _stages;
    }

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

    public void MoveNext()
    {
        int activeIndex = FindActiveIndex();

        if (activeIndex < stages.Count - 1)
        {
            activeStage = stages[activeIndex + 1];
            // Load next scene 
        }
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
