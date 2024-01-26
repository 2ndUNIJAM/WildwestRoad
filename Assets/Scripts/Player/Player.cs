using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private ReactiveProperty<int> _health = new();
    private ReactiveProperty<int> _ammo = new();
    private ReactiveProperty<int> _maxAmmo = new();
    private ReactiveProperty<PlayerActionType> _actionType = new();
}

public enum PlayerActionType
{
    Attack,
    Dodge,
    Reload
}