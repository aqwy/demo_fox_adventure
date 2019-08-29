using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FoxAdventure2d;

public class QuitGame : MonoBehaviour
{
    [SerializeField] private StartUI _stui;
    private void OnEnable()
    {      
        _stui.Quit();
        Debug.Log("quit");
    }
}
