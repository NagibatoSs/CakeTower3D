using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    public event Action<bool> OnMusicStateChanged;
    public bool IsMusicEnabled { get; private set; }

    void Start()
    {
        IsMusicEnabled = true;
        if (musicSource == null)
            musicSource = GetComponent<AudioSource>();
        musicSource.Play();
    }

    public void Play()
    {
        musicSource.Play();
    }

    public void Stop()
    {
        musicSource.Stop();
    }
    public void ChangeMuteMode()
    {
        if (!musicSource.mute)
            MuteMusic();
        else
            UnmuteMusic();
        OnMusicStateChanged?.Invoke(IsMusicEnabled);
    }
    public void MuteMusic()
    {
        musicSource.mute = true;
        IsMusicEnabled = false;
    }
    public void UnmuteMusic()
    {
        musicSource.mute = false;
        IsMusicEnabled = true;
    }
}
