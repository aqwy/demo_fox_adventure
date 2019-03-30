using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public AudioClip[] levelMusicAudioClips;

    private AudioSource _sourceSound;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        _sourceSound = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip currentClip = levelMusicAudioClips[scene.buildIndex];
        if (currentClip)
        {
            _sourceSound.clip = currentClip;
            _sourceSound.loop = true;
            _sourceSound.Play();
        }
    }
    public void ChangeVolume(float volume)
    {
        _sourceSound.volume = volume;
    }
}
