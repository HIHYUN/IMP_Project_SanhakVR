using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public Text text;
    public bool lockVol;

    void Start()
    {
        text.text = string.Format("Volume : {0}", SoundManager.Instance.vol*100);
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("Volume : {0}", SoundManager.Instance.vol*100);
    }


    public void OnSoundDown()
    {
        if (!lockVol)
            SoundManager.Instance.MusicVolumeMove(-Time.deltaTime*0.1f);
    }

    public void OnSoundUp()
    {
        if (!lockVol)
            SoundManager.Instance.MusicVolumeMove(Time.deltaTime * 0.1f);
    }

    public void Lock()
    {
        lockVol = true;
    }

    public void Unlock()
    {
        lockVol = false;
    }
}
