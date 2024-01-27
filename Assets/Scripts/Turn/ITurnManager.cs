using System;

public interface ITurnManager
{
    Player Player1 { get; }
    Player Player2 { get; }

    /// <summary>
    /// 플레이어가 이번 턴에 취할 액션을 설정한다.
    /// </summary>
    /// <param name="index">플레이어 넘버</param>
    /// <param name="actionType">취할 액션 타입</param>
    /// <returns>성공 여부</returns>
    bool SetPlayerAction(int index, PlayerActionType actionType);

    /// <summary>
    /// 턴 시작 시 호출
    /// </summary>
    event Action OnTurnStarted;

    /// <summary>
    /// 턴 종료 시 호출
    /// </summary>
    event Action<TurnResult> OnTurnEnded;

    /// <summary>
    /// 게임 시작 시 호출
    /// </summary>
    event Action OnGameStarted;

    /// <summary>
    /// 게임 종료 시 호출
    /// </summary>
    event Action<GameResult> OnGameEnded;
}