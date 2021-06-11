using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private List<AudioSource> _effectAudioSources = new List<AudioSource>();
    public List<AudioSource> effectAudioSources
    {
        get => _effectAudioSources;
    }

    [SerializeField]
    private List<AudioSource> _musicAudioSources = new List<AudioSource>();
    public List<AudioSource> musicAudioSources
    {
        get => _musicAudioSources;
    }

    public void EffectVolumeMove(float move)
    {
        VolumeMove(effectAudioSources, move);
    }

    public void MusicVolumeMove(float move)
    {
        VolumeMove(musicAudioSources, move);
    }

    public void AddEffect(AudioSource source)
    {
        effectAudioSources.Add(source);
    }

    public void AddMusic(AudioSource source)
    {
        musicAudioSources.Add(source);
    }

    public float vol;

    private void VolumeMove(List<AudioSource> target, float volume)
    {
        if (target.Count > 0)
            target.ForEach(source =>
            {
                if (source == null) return;
                source.volume += volume;
                vol = source.volume;
            });
    }
}
