using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestView : MonoBehaviour
{
    [SerializeField]
    private TurnManager _turnManager;

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

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _turnManager.SetPlayerAction(1, PlayerActionType.Reload);
            _turnManager.SetPlayerAction(2, PlayerActionType.Reload);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _turnManager.SetPlayerAction(1, PlayerActionType.Attack);
            _turnManager.SetPlayerAction(2, PlayerActionType.Reload);
        }
    }

    private void OnGameStart()
        => Debug.Log("Game Start!");

    private void OnGameEnd(GameResult result)
        => Debug.Log("Game End!");

    private void OnTurnStart()
        => Debug.Log("Turn Start!");

    private void OnTurnEnd(TurnResult result)
    {
        Debug.Log("Turn End!");
        Debug.Log(result);
    }
}