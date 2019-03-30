using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _cardBack;
    [SerializeField] private CardGameController _cardController;
    public int id
    {
        get { return _id; }
    }

    private int _id;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_cardBack.activeSelf && _cardController.canReveal)
        {
            _cardBack.SetActive(false);
            _cardController.cardRevealed(this);
        }
        Debug.Log("Clicked complete");
    }
    public void setCard(int id, Sprite card)
    {
        _id = id;
        GetComponent<Image>().sprite = card;
    }
    public void unreveal()
    {
        _cardBack.SetActive(true);
    }
}
