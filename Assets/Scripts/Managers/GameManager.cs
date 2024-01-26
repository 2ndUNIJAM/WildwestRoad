using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
}

public enum GameResult
{
    Player1Win,
    Player2Win,
    Draw
}