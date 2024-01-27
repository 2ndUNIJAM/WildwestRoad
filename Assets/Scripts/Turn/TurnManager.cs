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
    private PlayerData _player1PrevData;
    private PlayerData _player2PrevData;

    public Player Player1 => _player1;
    public Player Player2 => _player2;

    public event Action OnTurnStarted;
    public event Action<TurnResult> OnTurnEnded;
    public event Action OnGameStarted;
    public event Action<GameResult> OnGameEnded;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Start()
    {
        var factory = new PlayerFactory();

        _player1 = factory.CreatePlayer(GameManager.Instance.Player1Type);
        _player2 = factory.CreatePlayer(GameManager.Instance.Player2Type);

        OnGameStarted?.Invoke();
        StartTurn();
    }

    private void StartTurn()
    {
        _player1.ResetFlags();
        _player2.ResetFlags();

        _isPlayer1Acted = false;
        _isPlayer2Acted = false;

        // Capture players' data
        _player1PrevData = new PlayerData(_player1);
        _player2PrevData = new PlayerData(_player2);

        OnTurnStarted?.Invoke();
    }

    private void EndTurn()
    {
        // Perform players' action
        PerformAction(_player1, _player2);
        PerformAction(_player2, _player1);

        OnTurnEnded?.Invoke(CalculateTurnResult());

        if (_player1.Health <= 0 && _player2.Health > 0)
            OnGameEnded?.Invoke(GameResult.Player2Win);
        else if (_player1.Health > 0 && _player2.Health <= 0)
            OnGameEnded?.Invoke(GameResult.Player1Win);
        else if (_player1.Health <= 0 && _player2.Health <= 0)
            OnGameEnded?.Invoke(GameResult.Draw);
        else
            StartTurn();
    }

    private void PerformAction(Player player, Player enemy)
    {
        switch (player.ActionType)
        {
            case PlayerActionType.Attack:
                player.Fire(enemy);
                break;
            case PlayerActionType.Reload:
                player.ReloadAmmo();
                break;
            case PlayerActionType.Dodge:
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    private TurnResult CalculateTurnResult()
    {
        var player1CurData = new PlayerData(_player1);
        var player2CurData = new PlayerData(_player2);

        return new TurnResult
        {
            HealthDiff1 = player1CurData.Health - _player1PrevData.Health,
            HealthDiff2 = player2CurData.Health - _player2PrevData.Health,
            MaxAmmoDiff1 = player1CurData.MaxAmmo - _player1PrevData.MaxAmmo,
            MaxAmmoDiff2 = player2CurData.MaxAmmo - _player2PrevData.MaxAmmo,
            AmmoDiff1 = player1CurData.Ammo - _player1PrevData.Ammo,
            AmmoDiff2 = player2CurData.Ammo - _player2PrevData.Ammo,
            Action1 = _player1.ActionType,
            Action2 = _player2.ActionType,
            IsUltimateUsed1 = _player1.IsUltimateUsed,
            IsUltimateUsed2 = _player2.IsUltimateUsed,
        };
    }

    public bool SetPlayerAction(int index, PlayerActionType actionType)
    {
        switch (index)
        {
            case 1:
                if (_isPlayer1Acted)
                    return false;

                _player1.SetAction(actionType);
                _isPlayer1Acted = true;
                break;
            case 2:
                if (_isPlayer2Acted)
                    return false;

                _player2.SetAction(actionType);
                _isPlayer2Acted = true;
                break;
            default:
                throw new InvalidOperationException();
        }

        if (_isPlayer1Acted && _isPlayer2Acted)
            EndTurn();

        return true;
    }
}

public struct PlayerData
{
    public int Health;
    public int MaxAmmo;
    public int Ammo;
    public PlayerType Type;

    public PlayerData(Player player)
    {
        Health = player.Health;
        MaxAmmo = player.MaxAmmo;
        Ammo = player.Ammo;
        Type = player.PlayerType;
    }
}