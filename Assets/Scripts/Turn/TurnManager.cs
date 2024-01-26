using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour, ITurnManager
{
    public event Action OnTurnStarted;
    public event Action<PlayerActionType> OnTurnEnded;

    public bool SetPlayerAction(int index, PlayerActionType actionType)
    {
        throw new NotImplementedException();
    }
}