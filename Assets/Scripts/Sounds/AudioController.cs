using FoxAdventure2d;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _clickSound;

    public AudioClip[] musicTracks;
    public int trackNumber;

    void Start()
    {
        musicChange(trackNumber);
    }
    public void musicChange(int num)
    {
        if (BackgroundMusicPlayer.Instance != null)
        {
            trackNumber = num;
            BackgroundMusicPlayer.Instance.Mute();
            BackgroundMusicPlayer.Instance.ChangeMusic(musicTracks[trackNumber]);
            BackgroundMusicPlayer.Instance.Play();
            BackgroundMusicPlayer.Instance.Unmute(12.0f);          
        }
        /*else
        {
            BackgroundMusicPlayer.Instance.musicAudioClip = musicTracks[trackNumber];
        }*/
    }
    public void playSound(AudioClip clip)
    {
        _clickSound.PlayOneShot(clip);
    }
}
