using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioController audioControl;
    [Header("Menu Sounds Settings")]
    [SerializeField] private AudioClip optionsIconClick;
    [SerializeField] private AudioClip buttonPointDownSound;
    [Header("Menu Sounds Settings")]
    [SerializeField] private AudioClip minigameClick_one;
    public void playMenuClick()
    {
        audioControl.playSound(optionsIconClick);
    }
    public void playBringSound()
    {
        audioControl.playSound(buttonPointDownSound);
    }
    public void playMinigameClick()
    {
        audioControl.playSound(minigameClick_one);
    }
}
