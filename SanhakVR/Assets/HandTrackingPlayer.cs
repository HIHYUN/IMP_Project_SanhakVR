using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackingPlayer : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        SoundManager.Instance.AddMusic(source);

        source.volume = SoundManager.Instance.vol;
    }
}
