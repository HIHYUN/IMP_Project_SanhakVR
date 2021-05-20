using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TriggerCubeManager : MonoBehaviour
{
    public List<GameObject> signPrefabs = new List<GameObject>();
    private void Start() 
    {
        for(int i =0; i < signPrefabs.Count; i++)
        {
            GameObject spawn = Instantiate(signPrefabs[i]);
            spawn.transform.SetParent(this.transform, false);
        }
    }
}
