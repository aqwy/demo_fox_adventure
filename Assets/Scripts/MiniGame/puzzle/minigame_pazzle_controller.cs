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

    private int _foxID;
    private int _bagID;
    private int _chickenID;
    private int _currnetID;
    private Color _color;
    public bool islandSide { get; set; }

    private bool _foxActivity;
    private bool _bagActivity;
    private bool _chickenActivity;

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
        islandSide = true;
    }
    void Update()
    {
        activityCheck();
        if (rules())
        {
            Debug.Log("poidet");
        }
        else
        {
            Debug.Log("ne poidet");
        }
        Debug.Log("foxActiv: " + _foxActivity);
        Debug.Log("bagActiv: " + _bagActivity);
        Debug.Log("chikActiv: " + _chickenActivity);
        /*if (_currnetID == 0)
        {
            passjireImg.color = _color;
        }
        else if (_color.a != 1f)
        {
            _color.a = 1f;
            passjireImg.color = _color;
        }*/
    }
    /* public void checkFox()
     {
         if (_currnetID == 0)
         {
             foxImg.gameObject.SetActive(false);
             passjireImg.gameObject.SetActive(true);
             passjireImg.overrideSprite = foxSprite;
             _currnetID = _foxID;
             Debug.Log("event sys click fox");
         }
     }
     public void checkBag()
     {
         if (_currnetID == 0)
         {
             bagImg.gameObject.SetActive(false);
             passjireImg.gameObject.SetActive(true);
             passjireImg.overrideSprite = bagSprite;
             _currnetID = _bagID;
             Debug.Log("event sys click bag");
         }
     }
     public void checkChick()
     {
         if (_currnetID == 0)
         {
             chickenImg.gameObject.SetActive(false);
             passjireImg.gameObject.SetActive(true);
             passjireImg.overrideSprite = chickenSprite;
             _currnetID = _chickenID;
             Debug.Log("event sys click chick");
         }
     }*/

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
        /*else if(!islandSide && checkPerson(land_foxImg, _foxID) && nearLandPanel.activeSelf)
        {
            passjireImg.overrideSprite = foxSprite;
            passajireLandImg.overrideSprite = foxSprite;
        }*/
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
        /*else if (!islandSide && checkPerson(land_bagImg, _bagID) && nearLandPanel.activeSelf)
        {
            passjireImg.overrideSprite = bagSprite;
            passajireLandImg.overrideSprite = bagSprite;
        }*/
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
        /*else if (!islandSide && checkPerson(land_chickenImg, _chickenID) && nearLandPanel.activeSelf)
        {
            passjireImg.overrideSprite = chickenSprite;
            passajireLandImg.overrideSprite = chickenSprite;
        }*/
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
        bool landActF = land_foxImg.gameObject.activeSelf;
        bool landActB = land_bagImg.gameObject.activeSelf;
        bool landActC = land_chickenImg.gameObject.activeSelf;
        /* if (_foxActivity && _bagActivity)
         {
             return true;
         }
         else if (landActC && !landActF && !landActB)
         {
             return true;
         }
         else if (!landActC && landActF || landActB)
         {
             return true;
         }

         return false;*/

        if (_foxActivity && _chickenActivity || _chickenActivity && _bagActivity)
        {
            return false;
        }
        else if (landActF && landActC || landActC && landActB)
        {
            return false;
        }
        return true;
    }

    public void activityCheck()
    {
        _foxActivity = foxImg.gameObject.activeSelf;
        _bagActivity = bagImg.gameObject.activeSelf;
        _chickenActivity = chickenImg.gameObject.activeSelf;

        /*if (!_foxActivity)
        {
            _foxActivity = land_bagImg.gameObject.activeSelf;
        }
        if (!_bagActivity)
        {
            _bagActivity = land_bagImg.gameObject.activeSelf;
        }
        if (!_chickenActivity)
        {
            _chickenActivity = land_chickenImg.gameObject.activeSelf;
        }*/
    }

}
