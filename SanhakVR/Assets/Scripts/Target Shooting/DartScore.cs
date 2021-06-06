using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DartScore : MonoBehaviour
{
    public int score;
    public GameObject stuckdarts;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stuckdarts.transform.childCount == 4)
        {
            Debug.Log(score);
        }
    }
}
