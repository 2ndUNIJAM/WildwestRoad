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
    private List<Image> _winnerImages;
    [SerializeField]
    private Image _wantedImage;
    [SerializeField]
    private Image _bg;
    [SerializeField]
    private Color _bgColor;

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

        // TODO: 무승부 시 예외처리
        if (result == GameResult.Player1Win)
        {
            _winnerType = GameManager.Instance.Player1Type;
            _loserType = GameManager.Instance.Player2Type;
        }
        else if (result == GameResult.Player2Win)
        {
            _winnerType = GameManager.Instance.Player1Type;
            _loserType = GameManager.Instance.Player2Type;
        }

        _wantedImage.gameObject.SetActive(true);
        _wantedImage.sprite = _resultSprites[(int)_loserType];

        for (int i = 0; i < _winnerImages.Count; i++)
        {
            _winnerImages[i].gameObject.SetActive(i == (int)_winnerType);
        }

        var winnerImage = _winnerImages[(int)_winnerType];
        var startPos = winnerImage.GetComponent<RectTransform>().anchoredPosition;
        winnerImage.GetComponent<RectTransform>().anchoredPosition += new Vector2(-1920, 0);
        winnerImage.GetComponent<RectTransform>().DOAnchorPos(startPos, 1f).SetEase(Ease.OutCubic);

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
                case 0:
                    ReSelect();
                    break;
                case 1:
                    ReBattle();
                    break;
                case 2:
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
        Init(GameResult.Player1Win);
    }
}
