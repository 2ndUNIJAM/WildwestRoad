using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class ResultPanel : MonoBehaviour
{
    [SerializeField]
    private List<Image> _options;
    [SerializeField]
    private List<Sprite> _resultSprites;
    [SerializeField]
    private List<Sprite> _winnerSprites;
    [SerializeField]
    private Image _wantedImage;
    [SerializeField]
    private Image _winnerImage;
    [SerializeField]
    private Image _p1Image;
    [SerializeField]
    private Image _p2Image;
    [SerializeField]
    private Image _bg;
    [SerializeField]
    private Color _bgColor;
    [SerializeField]
    private GameObject[] _winTexts;

    private PlayerType _winnerType;
    private PlayerType _loserType;
    private GameResult _gameResult;

    private int _currentIndex;
    public int CurrentIndex
    {
        get => _currentIndex;
        set
        {
            _currentIndex = value;
            for (int i = 0; i < _options.Count; i++)
            {
                if (i == value)
                    _options[i].color = Color.black;
                else
                    _options[i].color = Color.black.SetAlpha(.5f);
            }
        }
    }

    public void Init(GameResult result)
    {
        _bg.gameObject.SetActive(true);
        _bg.color = Color.clear;
        _bg.DOColor(_bgColor, .2f);

        if (result == GameResult.Draw)
        {
            var p1Type = GameManager.Instance.Player1Type;
            var p2Type = GameManager.Instance.Player2Type;

            _wantedImage.gameObject.SetActive(true);
            _wantedImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            _wantedImage.sprite = _resultSprites[4];

            _p1Image.gameObject.SetActive(true);
            _p1Image.sprite = _winnerSprites[(int)p1Type];

            var pos1 = _p1Image.GetComponent<RectTransform>().anchoredPosition;
            _p1Image.GetComponent<RectTransform>().anchoredPosition += new Vector2(-1920, 0);
            _p1Image.GetComponent<RectTransform>().DOAnchorPos(pos1, 1f).SetEase(Ease.OutCubic);

            _p2Image.gameObject.SetActive(true);
            _p2Image.sprite = _winnerSprites[(int)p2Type];

            var pos2 = _p2Image.GetComponent<RectTransform>().anchoredPosition;
            _p2Image.GetComponent<RectTransform>().anchoredPosition += new Vector2(1920, 0);
            _p2Image.GetComponent<RectTransform>().DOAnchorPos(pos2, 1f).SetEase(Ease.OutCubic);

            CurrentIndex = 2;

            return;
        }

        if (result == GameResult.Player1Win)
        {
            _winnerType = GameManager.Instance.Player1Type;
            _loserType = GameManager.Instance.Player2Type;
            _winTexts[0].SetActive(true);
        }
        else if (result == GameResult.Player2Win)
        {
            _winnerType = GameManager.Instance.Player2Type;
            _loserType = GameManager.Instance.Player1Type;
            _winTexts[1].SetActive(true);
        }

        _wantedImage.gameObject.SetActive(true);
        _wantedImage.sprite = _resultSprites[(int)_loserType];

        _winnerImage.gameObject.SetActive(true);
        _winnerImage.sprite = _winnerSprites[(int)_winnerType];

        var startPos = _winnerImage.GetComponent<RectTransform>().anchoredPosition;
        _winnerImage.GetComponent<RectTransform>().anchoredPosition += new Vector2(-1920, 0);
        _winnerImage.GetComponent<RectTransform>().DOAnchorPos(startPos, 1f).SetEase(Ease.OutCubic);

        CurrentIndex = 2;
    }

    private void Update()
    {
        if (_gameResult == GameResult.Player1Win && Input.GetKeyDown(KeyCode.S) && _currentIndex > 0)
        {
            CurrentIndex--;
        }
        else if (_gameResult == GameResult.Player1Win && Input.GetKeyDown(KeyCode.W) && _currentIndex < 2)
        {
            CurrentIndex++;
        }
        else if (_gameResult == GameResult.Draw && Input.GetKeyDown(KeyCode.S) && _currentIndex > 0)
        {
            CurrentIndex--;
        }
        else if (_gameResult == GameResult.Draw && Input.GetKeyDown(KeyCode.W) && _currentIndex > 2)
        {
            CurrentIndex++;
        }
        else if (_gameResult == GameResult.Player2Win && Input.GetKeyDown(KeyCode.DownArrow) && _currentIndex > 0)
        {
            CurrentIndex--;
        }
        else if (_gameResult == GameResult.Player2Win && Input.GetKeyDown(KeyCode.UpArrow) && _currentIndex > 2)
        {
            CurrentIndex++;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            switch (_currentIndex)
            {
                case 2:
                    ReSelect();
                    break;
                case 1:
                    ReBattle();
                    break;
                case 0:
                    QuitGame();
                    break;
            }
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReBattle()
    {
        GameManager.Instance.StartGame();
    }

    public void ReSelect()
    {
        GameManager.Instance.BackToMain();
    }

    [ContextMenu("Test")]
    public void Test()
    {
        Init(GameResult.Player2Win);
    }
}
