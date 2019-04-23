using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private minigame_pazzle_controller _controller;
    public Button myButton;

    private Vector3 _newScale;
    private ColorBlock _blockColor;
    void Start()
    {
        myButton.transform.localScale = Vector3.one;
        _newScale = new Vector3(1.1f, 1.1f, 1.1f);
        _blockColor = myButton.colors;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (myButton.transform.localScale != _newScale)
        {
            if (!_controller.rules())
            {
                myButton.enabled = false;
                _blockColor.normalColor = Color.red;
                _blockColor.highlightedColor = new Color32(225, 22, 22, 255);
                myButton.colors = _blockColor;
            }
            else
            {
                myButton.enabled = true;
                _blockColor.normalColor = Color.green;
                _blockColor.highlightedColor = new Color32(22, 225, 22, 255);
                myButton.colors = _blockColor;
            }

            myButton.transform.localScale = _newScale;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (myButton.transform.localScale != Vector3.one)
        {
            _blockColor.normalColor = Color.white;
            _blockColor.highlightedColor = new Color32(255, 255, 255, 255);
            myButton.colors = _blockColor;

            myButton.transform.localScale = Vector3.one;
        }
    }
    public void startRightTurn()
    {
        Debug.Log("bool is: " + _controller.islandSide);
        if (!_controller.islandSide)
        {
            _controller.nearLandPanel.gameObject.SetActive(false);
            _controller.nearIslandPanel.gameObject.SetActive(true);
            Debug.Log("moving right");
            _controller.islandSide = true;
        }
    }
    public void startLeftTurn()
    {
        if (_controller.islandSide)
        {
            _controller.nearLandPanel.gameObject.SetActive(true);
            _controller.nearIslandPanel.gameObject.SetActive(false);
            Debug.Log("moving left");
            _controller.islandSide = false;
        }
    }
}
