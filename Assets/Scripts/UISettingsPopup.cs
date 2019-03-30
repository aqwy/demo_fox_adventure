using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISettingsPopup : MonoBehaviour
{
    public Slider volumSlider;
    public Slider difficultySlider;

    private MusicController _musicControl;
    private void Start()
    {
        _musicControl = FindObjectOfType<MusicController>();
        volumSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetMasterDifficulty();
    }
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            _musicControl.ChangeVolume(volumSlider.value);
        }
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        PlayerPrefsManager.SetMasterVolume(volumSlider.value);
        PlayerPrefsManager.SetMasterDifficulty(difficultySlider.value);
        gameObject.SetActive(false);
    }

    public void SetDefault()
    {
        volumSlider.value = 0.5f;
        difficultySlider.value = 1.0f;
    }
}
