using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private List<AudioSource> _effectAudioSources = new List<AudioSource>();
    public List<AudioSource> effectAudioSources
    {
        get => _effectAudioSources;
    }

    private List<AudioSource> _musicAudioSources = new List<AudioSource>();
    public List<AudioSource> musicAudioSources
    {
        get => _musicAudioSources;
    }

    public void EffectVolumeMove(float volume)
    {
        VolumeMove(effectAudioSources, volume);
    }

    public void MusicVolumeMove(float volume)
    {
        VolumeMove(musicAudioSources, volume);
    }

    public void AddEffect(AudioSource source)
    {
        effectAudioSources.Add(source);
    }

    public void AddMusic(AudioSource source)
    {
        musicAudioSources.Add(source);
    }

    private void VolumeMove(List<AudioSource> target, float volume)
    {
        if (target.Count > 0)
            target.ForEach(effectSource => effectSource.volume = volume);
    }
}
