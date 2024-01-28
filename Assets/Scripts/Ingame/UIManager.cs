
using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TurnManager _turnManager;
    [SerializeField]
    private PlayerUI _playerUI1;
    [SerializeField]
    private PlayerUI _playerUI2;
    [SerializeField]
    private CutSceneAnimation _cutSceneAnimation;
    [SerializeField]
    private TextMeshProUGUI _roundText;
    [SerializeField]
    private TextMeshProUGUI _countText;
    [SerializeField]
    private ResultPanel _resultPanel;

    private bool _canSelectAction = false;
    private bool _isGameRunning = false;
    private bool _hasPlayer1Selected = false;
    private bool _hasPlayer2Selected = false;
    private int _player1DodgeStreak = 0;
    private int _player2DodgeStreak = 0;
    private int _roundNum = 1;
    private GameResult _gameResult;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        _turnManager.OnTurnStarted += OnTurnStart;
        _turnManager.OnTurnEnded += OnTurnEnd;
        _turnManager.OnGameStarted += OnGameStart;
        _turnManager.OnGameEnded += OnGameEnd;
    }

    private IEnumerator GameStartCoroutine()
    {
        _playerUI1.Init(new PlayerData(_turnManager.Player1));
        _playerUI2.Init(new PlayerData(_turnManager.Player2));

        _isGameRunning = true;

        yield return null;

        _playerUI1.SetReady(false, _player1DodgeStreak);
        _playerUI2.SetReady(false, _player2DodgeStreak);
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlaySFX(SoundType.CountGame);
        for (int i = 0; i < 3; i++)
        {
            _countText.text = (3 - i).ToString();
            
            yield return new WaitForSeconds(1f);
        }

        _countText.text = "Start!";
        yield return new WaitForSeconds(1f);

        SoundManager.Instance.PlayBGM(SoundType.FirstBGM);
        _countText.gameObject.SetActive(false);

        _canSelectAction = true;
    }
    private IEnumerator BgmCouroutine()
    {
        SoundManager.Instance.PlayBGM(SoundType.FirstBGM);
    }
    private IEnumerator TurnStartCoroutine()
    {
        yield return null;
    }

    private IEnumerator TurnEndCoroutine(TurnResult result)
    {
        _canSelectAction = false;
        Debug.Log(result);

        StartCoroutine(_playerUI1.CylinderAnimation(1f));
        StartCoroutine(_playerUI2.CylinderAnimation(1f));
        yield return new WaitForSeconds(1f);

        yield return _cutSceneAnimation.AnimationCoroutine(result);

        _playerUI1.UpdatePlayerData(result, 1);
        _playerUI2.UpdatePlayerData(result, 2);

        _playerUI1.SetReady(false, _player1DodgeStreak);
        _playerUI2.SetReady(false, _player2DodgeStreak);

        if (!_isGameRunning)
        {
            // 게임 종료 시 여기 호출됨
            yield return new WaitForSeconds(1f);

            if (_gameResult == GameResult.Draw)
            {
                SoundManager.Instance.PlaySFX(SoundType.DrawGame);
            }
            else SoundManager.Instance.PlaySFX(SoundType.WinGame);
            Debug.Log(_gameResult);
            _resultPanel.Init(_gameResult);
            yield break;
        }

        _canSelectAction = true;

        _hasPlayer1Selected = false;
        _hasPlayer2Selected = false;

        _roundNum++;
        _roundText.text = $"Round {_roundNum}";
    }

    private void Update()
    {
        if (!_canSelectAction || !_isGameRunning)
            return;

        if (Input.GetKeyDown(KeyCode.Z) && !_hasPlayer1Selected)
        {
            _turnManager.SetPlayerAction(1, PlayerActionType.Attack);
            _player1DodgeStreak = 0;
            _hasPlayer1Selected = true;
            _playerUI1.SetReady(true, _player1DodgeStreak);
        }

        if (Input.GetKeyDown(KeyCode.X) && !_hasPlayer1Selected)
        {
            if (_player1DodgeStreak >= 2)
                return;

            _turnManager.SetPlayerAction(1, PlayerActionType.Dodge);
            _player1DodgeStreak++;
            _hasPlayer1Selected = true;
            _playerUI1.SetReady(true, _player1DodgeStreak);
        }

        if (Input.GetKeyDown(KeyCode.C) && !_hasPlayer1Selected)
        {
            _turnManager.SetPlayerAction(1, PlayerActionType.Reload);
            _player1DodgeStreak = 0;
            _hasPlayer1Selected = true;
            _playerUI1.SetReady(true, _player1DodgeStreak);
        }

        if (Input.GetKeyDown(KeyCode.Comma) && !_hasPlayer2Selected)
        {
            _turnManager.SetPlayerAction(2, PlayerActionType.Attack);
            _player2DodgeStreak = 0;
            _hasPlayer2Selected = true;
            _playerUI2.SetReady(true, _player2DodgeStreak);
        }

        if (Input.GetKeyDown(KeyCode.Period) && !_hasPlayer2Selected)
        {
            if (_player2DodgeStreak >= 2)
                return;

            _turnManager.SetPlayerAction(2, PlayerActionType.Dodge);
            _player2DodgeStreak++;
            _hasPlayer2Selected = true;
            _playerUI2.SetReady(true, _player2DodgeStreak);
        }

        if (Input.GetKeyDown(KeyCode.Slash) && !_hasPlayer2Selected)
        {
            _turnManager.SetPlayerAction(2, PlayerActionType.Reload);
            _player2DodgeStreak = 0;
            _hasPlayer2Selected = true;
            _playerUI2.SetReady(true, _player2DodgeStreak);
        }
    }

    private void OnGameStart()
        => StartCoroutine(GameStartCoroutine());

    private void OnGameEnd(GameResult result)
    {
        _isGameRunning = false;
        _gameResult = result;
    }

    private void OnTurnStart()
        => StartCoroutine(TurnStartCoroutine());

    private void OnTurnEnd(TurnResult result)
        => StartCoroutine(TurnEndCoroutine(result));
}
