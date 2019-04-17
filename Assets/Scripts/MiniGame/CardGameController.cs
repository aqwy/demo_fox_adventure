using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CardGameController : MonoBehaviour
{
    [SerializeField] private MemoryCard _originalCard;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private TextMeshProUGUI _scoreLable;
    [SerializeField] private TextMeshProUGUI _livesLable;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _lostPanel;
    [SerializeField] private Image _lostImg;

    public int lives = 3;

    public const int gridRows = 3;
    public const int gridCols = 4;
    public const float offsetX = 160f;
    public const float offsetY = 150f;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private int _score;
    private int _lives;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    private void Awake()
    {
        _lostImg.raycastTarget = false;
        _lives = lives;
        _livesLable.text = "Lives: " + lives;
        _scoreLable.text = "Score: " + _score;
        _winPanel.gameObject.SetActive(false);
        _lostPanel.gameObject.SetActive(false);
    }
    void Start()
    {

    }
    private int[] suffleCards(int[] numbers)
    {
        int[] newArr = numbers.Clone() as int[];
        for (int i = 0; i < newArr.Length; i++)
        {
            int temp = newArr[i];
            int rand = Random.Range(i, numbers.Length);
            newArr[i] = newArr[rand];
            newArr[rand] = temp;
        }
        return newArr;
    }
    public void cardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(checkMath());
        }
    }

    private IEnumerator checkMath()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            _scoreLable.text = "Score: " + _score;

            if (_score == 6)
            {
                _winPanel.gameObject.SetActive(true);
            }
        }
        else
        {
            lives--;
            _livesLable.text = "Lives: " + lives;
            yield return new WaitForSeconds(0.5f);


            if (lives <= 0)
            {
                _lostPanel.gameObject.SetActive(true);
                _lostImg.raycastTarget = true;
            }

            _firstRevealed.unreveal();
            _secondRevealed.unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }
    public void minigameStart()
    {
        Vector3 startPos = _originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        numbers = suffleCards(numbers);

        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = _originalCard;
                }
                else
                {
                    card = Instantiate(_originalCard);
                    card.transform.SetParent(GameObject.Find("CardPanel").transform, false);
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.setCard(id, _sprites[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;

                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    public void restartMinigame()
    {
        cardClonesDestroy();

        _originalCard.unreveal();
        _firstRevealed = null;
        _secondRevealed = null;
        _lostImg.raycastTarget = false;

        _score = 0;
        _scoreLable.text = "Score: " + _score;

        lives = _lives;
        _livesLable.text = "Lives: " + lives;

        minigameStart();
    }

    public void cardClonesDestroy()
    {
        GameObject childs = GameObject.Find("CardPanel").transform.gameObject;
        int count = GameObject.Find("CardPanel").transform.childCount;
        for (int i = count - 1; i > 0; i--)
        {
            Destroy(childs.transform.GetChild(i).gameObject);
        }
    }
}
