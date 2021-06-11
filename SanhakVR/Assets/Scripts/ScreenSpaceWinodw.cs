using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSpaceWinodw : MonoBehaviour
{
    private void Awake()
    {
        var canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        canvas.planeDistance = 1;
    }
}
