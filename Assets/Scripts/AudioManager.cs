using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Audio;

#pragma warning disable 618
#pragma warning disable 649

/// <summary>
/// Contains all methods for audio settings
/// </summary>
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip[] clip;

    private void Start()
    {
        LoadSettings();
    }

    /// <summary>
    /// Plays an audio on an especific action
    /// </summary>
    /// <param name="actions"></param>
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
            case 4:
                soundSource.PlayOneShot(clip[4]);
                break;
            case 5:
                soundSource.PlayOneShot(clip[5]);
                break;
            case 6:
                soundSource.PlayOneShot(clip[6]);
                break;
            case 7:
                soundSource.PlayOneShot(clip[7]);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Stores the settings into the device
    /// </summary>
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSource.volume);
        PlayerPrefs.SetFloat("soundVolume", soundSource.volume);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Get the settings stored and loads the values
    /// </summary>
    private void LoadSettings()
    {
        musicSource.volume = PlayerPrefs.GetFloat("musicVolume", musicSource.volume);
        soundSource.volume = PlayerPrefs.GetFloat("soundVolume", soundSource.volume);
    }

    /// <summary>
    /// Stops all the audios
    /// </summary>
    public void StopMusic()
    {
        musicSource.Stop();
    }
}