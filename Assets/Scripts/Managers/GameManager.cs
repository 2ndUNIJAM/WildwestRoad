using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField]
    private PlayerType _player1Type;
    [SerializeField]
    private PlayerType _player2Type;

    public PlayerType Player1Type => _player1Type;
    public PlayerType Player2Type => _player2Type;
}

public enum GameResult
{
    Player1Win,
    Player2Win,
    Draw
}