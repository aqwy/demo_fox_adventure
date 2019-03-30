using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _scoreLable;
    [SerializeField] private Button _winButton;

    private void Awake()
    {
        _winButton.gameObject.SetActive(false);
    }

    public void showText(string msg)
    {
        _scoreLable.text = msg;
    }
    public void winConditions()
    {
        _winButton.gameObject.SetActive(true);
    }
}
