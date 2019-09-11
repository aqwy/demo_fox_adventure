using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FoxAdventure2d;
using System.Diagnostics;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private StartUI _stui;
    private void OnEnable()
    {
        Process.GetCurrentProcess().Kill();
        /*_stui.Quit();
        Debug.Log("quit");*/
    }
}
