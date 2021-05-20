using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerCubeManager : MonoBehaviour
{
    public List<GameObject> signPrefabs = new List<GameObject>();
    private Sequence instantMotion;
    private void Start() 
    {
        instantMotion = DOTween.Sequence();
        instantMotion.SetAutoKill(false);

        float step = 0;
        for(int i =0; i < signPrefabs.Count; i++)
        {
            GameObject spawn = Instantiate(signPrefabs[i]);
            spawn.name = signPrefabs[i].name;
            spawn.transform.SetParent(this.transform, false);
            instantMotion.Join(spawn.transform.DOLocalMoveX(step,2f).SetEase(Ease.OutQuint));
            step += 1f;
        }

    }

    
    private void Update() 
    {
        if(this.transform.childCount ==0)
        {
            Debug.Log(" Clear");
        }
    }
}
