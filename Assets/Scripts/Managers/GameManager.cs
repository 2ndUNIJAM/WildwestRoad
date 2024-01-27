using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField]
    private PlayerType _player1Type;
    [SerializeField]
    private PlayerType _player2Type;

    public PlayerType Player1Type => _player1Type;
    public PlayerType Player2Type => _player2Type;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void GetData(int _1p, int _2p)
    {
        _player1Type = ConvertToPlayerType(_1p);
        _player2Type = ConvertToPlayerType(_2p);
    }

    private PlayerType ConvertToPlayerType(int value)
    {
        if (Enum.IsDefined(typeof(PlayerType), value))
        {
            return (PlayerType)value;
        }
        else
        {
            // 예외 처리 또는 기본값 지정
            return PlayerType.A; // 또는 다른 기본값으로 변경
        }
        Debug.Log(_player1Type);
        Debug.Log(_player2Type);
    }
}


public enum GameResult
{
    Player1Win,
    Player2Win,
    Draw
}
