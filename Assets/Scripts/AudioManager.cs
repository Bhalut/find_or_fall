using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

#pragma warning disable 618
#pragma warning disable 649

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip[] clip;

    private void Start()
    {
        LoadSettings();
    }

    public void ShotAudio(int actions)
    {
        switch (actions)
        {
            case 0:
                musicSource.PlayOneShot(clip[0]);
                break;
            case 1:
                musicSource.PlayOneShot(clip[1]);
                break;
            case 2:
                soundSource.PlayOneShot(clip[2]);
                break;
            case 3:
                soundSource.PlayOneShot(clip[3]);
                break;
            default:
                break;
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSource.volume);
        PlayerPrefs.SetFloat("soundVolume", soundSource.volume);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        musicSource.volume = PlayerPrefs.GetFloat("musicVolume", musicSource.volume);
        soundSource.volume = PlayerPrefs.GetFloat("soundVolume", soundSource.volume);
    }
}