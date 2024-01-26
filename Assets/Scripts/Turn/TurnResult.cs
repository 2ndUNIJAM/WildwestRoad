using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TurnResult
{
    public int HealthDiff1;
    public int AmmoDiff1;
    public int MaxAmmoDiff1;
    public int HealthDiff2;
    public int AmmoDiff2;
    public int MaxAmmoDiff2;
    public PlayerActionType Action1;
    public PlayerActionType Action2;
    public bool IsUltimateUsed1;
    public bool IsUltimateUsed2;
}