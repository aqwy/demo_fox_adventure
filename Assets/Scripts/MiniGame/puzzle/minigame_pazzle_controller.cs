using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class minigame_pazzle_controller : MonoBehaviour
{
    public Image foxImg;
    public Image chickenImg;
    public Image bagImg;
    public Image land_foxImg;
    public Image land_chickenImg;
    public Image land_bagImg;
    public Image passjireImg;
    public Image passajireLandImg;

    public Sprite foxSprite;
    public Sprite bagSprite;
    public Sprite chickenSprite;

    public GameObject nearIslandPanel;
    public GameObject nearLandPanel;
    public GameObject winPanel;

    private int _foxID;
    private int _bagID;
    private int _chickenID;
    private int _currnetID;
    private Color _color;
    public bool islandSide { get; set; }

    private bool _foxActivity;
    private bool _bagActivity;
    private bool _chickenActivity;
    private bool _landActF;
    private bool _landActB;
    private bool _landActC;

    void Start()
    {
        _currnetID = 0;
        _foxID = 1;
        _bagID = 2;
        _chickenID = 3;
        _color = passjireImg.color;
        _color.a = 0f;

        passjireImg.gameObject.SetActive(false);
        passajireLandImg.gameObject.SetActive(false);
        nearLandPanel.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(false);

        islandSide = true;
    }
    void Update()
    {
        rules();
    }

    public bool checkPerson(Image img, int id)
    {
        if (_currnetID == 0)
        {
            img.gameObject.SetActive(false);
            passjireImg.gameObject.SetActive(true);
            passajireLandImg.gameObject.SetActive(true);
            _currnetID = id;
            return true;
        }
        return false;
    }

    public void checkFox()
    {
        if (islandSide && checkPerson(foxImg, _foxID))
        {
            passjireImg.overrideSprite = foxSprite;
            passajireLandImg.overrideSprite = foxSprite;
        }
    }
    public void checkLandFox()
    {
        if (!islandSide && checkPerson(land_foxImg, _foxID))
        {
            passjireImg.overrideSprite = foxSprite;
            passajireLandImg.overrideSprite = foxSprite;
        }
    }
    public void checkBag()
    {
        if (islandSide && checkPerson(bagImg, _bagID))
        {
            passjireImg.overrideSprite = bagSprite;
            passajireLandImg.overrideSprite = bagSprite;
        }
    }
    public void checkLandBag()
    {
        if (!islandSide && checkPerson(land_bagImg, _bagID))
        {
            passjireImg.overrideSprite = bagSprite;
            passajireLandImg.overrideSprite = bagSprite;
        }
    }
    public void checkChick()
    {
        if (islandSide && checkPerson(chickenImg, _chickenID))
        {
            passjireImg.overrideSprite = chickenSprite;
            passajireLandImg.overrideSprite = chickenSprite;
        }
    }
    public void checkLandChiken()
    {
        if (!islandSide && checkPerson(land_chickenImg, _chickenID))
        {
            passjireImg.overrideSprite = chickenSprite;
            passajireLandImg.overrideSprite = chickenSprite;
        }
    }

    public void passajirCheck()
    {
        if (islandSide)
        {
            if (_currnetID == _foxID)
            {
                setPassajireImg(foxImg);
            }
            else if (_currnetID == _bagID)
            {
                setPassajireImg(bagImg);
            }
            else if (_currnetID == _chickenID)
            {
                setPassajireImg(chickenImg);
            }
        }
        if (!islandSide)
        {
            if (_currnetID == _foxID)
            {
                setPassajireImg(land_foxImg);
            }
            else if (_currnetID == _bagID)
            {
                setPassajireImg(land_bagImg);
            }
            else if (_currnetID == _chickenID)
            {
                setPassajireImg(land_chickenImg);
            }
        }
    }

    private void setPassajireImg(Image img)
    {
        img.gameObject.SetActive(true);
        passjireImg.gameObject.SetActive(false);
        passajireLandImg.gameObject.SetActive(false);
        _currnetID = 0;
    }

    public bool rules()
    {
        _landActF = land_foxImg.gameObject.activeSelf;
        _landActB = land_bagImg.gameObject.activeSelf;
        _landActC = land_chickenImg.gameObject.activeSelf;
        _foxActivity = foxImg.gameObject.activeSelf;
        _bagActivity = bagImg.gameObject.activeSelf;
        _chickenActivity = chickenImg.gameObject.activeSelf;

        if(_landActB && _landActC &&_landActF)
        {
            winPanel.gameObject.SetActive(true);
        }

        if (_foxActivity && _chickenActivity || _chickenActivity && _bagActivity)
        {
            return false;
        }
        else if (_landActF && _landActC || _landActC && _landActB)
        {
            return false;
        }
        return true;
    }
}
