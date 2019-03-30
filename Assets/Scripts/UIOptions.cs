using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOptions : MonoBehaviour
{
    [SerializeField] private UISettingsPopup _settingPopup;
    private void Start()
    {
        _settingPopup.Close();
    }
    public void OnSettingsOpen()
    {
        _settingPopup.Open();      
    }
}
