using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearUI : MonoBehaviour
{
    public Canvas canvas;
    public Transform player;

    private void Start()
    {
        canvas.worldCamera = Camera.main;
    }
}
