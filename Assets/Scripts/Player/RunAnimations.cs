using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimations : MonoBehaviour
{
    public GAF.Core.GAFMovieClip _gafMovie;

    private float _frames;
    private float _currentFrames;
    void Start()
    {
        _gafMovie = GetComponent<GAF.Core.GAFMovieClip>();
        _frames = _gafMovie.getFramesCount();
        _currentFrames = _gafMovie.internalFrameNumber;

        Debug.Log("isInitialized => " + _gafMovie.isInitialized);
        Debug.Log("isPlaying => " + _gafMovie.isPlaying());
        Debug.Log("frames => " + _frames);
        Debug.Log("currentFrames => " + _currentFrames);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _gafMovie.play();
        }

        if (_currentFrames == _frames)
        {
            _gafMovie.stop();
            Debug.Log("Stoped");
        }
        _currentFrames = _gafMovie.internalFrameNumber;
        Debug.Log("currentFrames => " + _currentFrames);
    }

    private void animFrames()
    {
        Debug.Log("getFramesCount => " + _gafMovie.currentFrameNumber);
    }
}
