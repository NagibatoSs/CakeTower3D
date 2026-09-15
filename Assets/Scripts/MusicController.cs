using Assets.Scripts.UI;
using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour, IAudioState
{
    [SerializeField] private AudioSource musicSource;
    public bool IsEnabled => isMusicEnabled;

    public event Action<bool> OnStateChanged;

    private bool isMusicEnabled;

    void Start()
    {
        isMusicEnabled = true;
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
    }
    public void MuteMusic()
    {
        musicSource.mute = true;
        isMusicEnabled = false;
        OnStateChanged?.Invoke(IsEnabled);
    }
    public void UnmuteMusic()
    {
        musicSource.mute = false;
        isMusicEnabled = true;
        OnStateChanged?.Invoke(IsEnabled);
    }
}
