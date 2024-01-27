
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using JetBrains.Annotations;

public class UIManager : MonoBehaviour
{
    // TODO: 의존성 있는 컴포턴트 [SerializeField]로 계속 추가해서 사용
    [SerializeField]
    private TurnManager _turnManager;
    [SerializeField]
    private PlayerUI _playerUI1;
    [SerializeField]
    private PlayerUI _playerUI2;
    [SerializeField]
    private CutSceneAnimation _cutSceneAnimation;

    private bool _canSelectAction = false;
    private bool _isGameRunning = false;
    private bool _hasPlayer1Selected = false;
    private bool _hasPlayer2Selected = false;
    private int _roundNum = 0;

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
        yield return null;

        // TODO: 시작 카운팅

        _isGameRunning = true;
        _canSelectAction = true;
    }

    private IEnumerator GameEndCoroutine(GameResult result)
    {
        _isGameRunning = false;
        // TODO: 게임 종료 시 시퀀스
        yield return null;
    }

    private IEnumerator TurnStartCoroutine()
    {
        _roundNum++;
        yield return new WaitForSeconds(.25f);

        _playerUI1.SetReady(false);
        _playerUI2.SetReady(false);
        _hasPlayer1Selected = false;
        _hasPlayer2Selected = false;
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

        _canSelectAction = true;
    }

    private void Update()
    {
        if (!_canSelectAction || !_isGameRunning)
            return;

        if (Input.GetKeyDown(KeyCode.Z) && !_hasPlayer1Selected)
        {
            _turnManager.SetPlayerAction(1, PlayerActionType.Attack);
            _hasPlayer1Selected = true;
            _playerUI1.SetReady(true);
        }

        if (Input.GetKeyDown(KeyCode.X) && !_hasPlayer1Selected)
        {
            _turnManager.SetPlayerAction(1, PlayerActionType.Dodge);
            _hasPlayer1Selected = true;
            _playerUI1.SetReady(true);
        }

        if (Input.GetKeyDown(KeyCode.C) && !_hasPlayer1Selected)
        {
            _turnManager.SetPlayerAction(1, PlayerActionType.Reload);
            _hasPlayer1Selected = true;
            _playerUI1.SetReady(true);
        }

        if (Input.GetKeyDown(KeyCode.B) && !_hasPlayer2Selected)
        {
            _turnManager.SetPlayerAction(2, PlayerActionType.Attack);
            _hasPlayer2Selected = true;
            _playerUI2.SetReady(true);
        }

        if (Input.GetKeyDown(KeyCode.N) && !_hasPlayer2Selected)
        {
            _turnManager.SetPlayerAction(2, PlayerActionType.Dodge);
            _hasPlayer2Selected = true;
            _playerUI2.SetReady(true);
        }

        if (Input.GetKeyDown(KeyCode.M) && !_hasPlayer2Selected)
        {
            _turnManager.SetPlayerAction(2, PlayerActionType.Reload);
            _hasPlayer2Selected = true;
            _playerUI2.SetReady(true);
        }
    }

    private void OnGameStart()
        => StartCoroutine(GameStartCoroutine());

    private void OnGameEnd(GameResult result)
        => StartCoroutine(GameEndCoroutine(result));

    private void OnTurnStart()
        => StartCoroutine(TurnStartCoroutine());

    private void OnTurnEnd(TurnResult result)
        => StartCoroutine(TurnEndCoroutine(result));
}
