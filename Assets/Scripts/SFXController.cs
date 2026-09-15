using Assets.Scripts.UI;
using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour, IAudioState
{
    private AudioSource audioSource;

    public event Action<bool> OnStateChanged;
    public bool IsEnabled => isEnabled;
    private bool isEnabled;

    void Start()
    {
        isEnabled = true;
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void Play(SFXData data)
    {
        if (data == null) return;
        audioSource.pitch = UnityEngine.Random.Range(data.MinPitch, data.MaxPitch);
        audioSource.PlayOneShot(data.Clip);
        audioSource.pitch = 1f;
    }

    public void ChangeMuteMode()
    {
        if (!audioSource.mute)
            MuteSFX();
        else
            UnmuteSFX();

    }
    public void MuteSFX()
    {
        audioSource.mute = true;
        isEnabled = false;
        OnStateChanged?.Invoke(IsEnabled);
    }
    public void UnmuteSFX()
    {
        audioSource.mute = false;
        isEnabled = true;
        OnStateChanged?.Invoke(IsEnabled);
    }
}
