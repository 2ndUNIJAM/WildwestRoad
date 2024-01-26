using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurnManager : MonoBehaviour, ITurnManager
{
    private Player _player1;
    private Player _player2;
    private bool _isPlayer1Acted = false;
    private bool _isPlayer2Acted = false;

    public Player Player1 => _player1;
    public Player Player2 => _player2;

    public event Action OnTurnStarted;
    public event Action<TurnResult> OnTurnEnded;
    public event Action OnGameStarted;
    public event Action<GameResult> OnGameEnded;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        OnGameStarted?.Invoke();
        StartTurn();
    }

    private void StartTurn()
    {
        _player1.ResetFlags();
        _player2.ResetFlags();
        OnTurnStarted?.Invoke();
    }

    private void EndTurn()
    {
        // TODO: TurnResult 만들어야함

        OnTurnEnded?.Invoke(new TurnResult());

        if (_player1.Health <= 0 && _player2.Health > 0)
            OnGameEnded?.Invoke(GameResult.Player1Win);
        else if (_player1.Health > 0 && _player2.Health <= 0)
            OnGameEnded?.Invoke(GameResult.Player2Win);
        else if (_player1.Health <= 0 && _player2.Health <= 0)
            OnGameEnded?.Invoke(GameResult.Draw);
        else
            StartTurn();
    }

    public bool SetPlayerAction(int index, PlayerActionType actionType)
    {
        switch (index)
        {
            case 1:
                if (_isPlayer1Acted)
                    return false;

                _player1.SetAction(actionType);
                break;
            case 2:
                if (_isPlayer2Acted)
                    return false;

                _player2.SetAction(actionType);
                break;
            default:
                throw new InvalidOperationException();
        }

        if (_isPlayer1Acted && _isPlayer2Acted)
            EndTurn();

        return true;
    }
}