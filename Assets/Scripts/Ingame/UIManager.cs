using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // TODO: 의존성 있는 컴포턴트 [SerializeField]로 계속 추가해서 사용
    [SerializeField]
    private TurnManager _turnManager;

    private bool _canSelectAction = false;

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
        // TODO: 게임 시작 시 시퀀스
        yield return null;
    }

    private IEnumerator GameEndCoroutine(GameResult result)
    {
        // TODO: 게임 종료 시 시퀀스
        yield return null;
    }

    private IEnumerator TurnStartCoroutine()
    {
        _canSelectAction = true;
        // TODO: 턴 시작 시 시퀀스
        yield return null;
    }

    private IEnumerator TurnEndCoroutine(TurnResult result)
    {
        _canSelectAction = false;
        // TODO: 턴 종료 시 시퀀스
        yield return null;
    }

    private void Update()
    {
        if (!_canSelectAction)
            return;

        // TODO: 턴 시작 후 인풋 받기
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