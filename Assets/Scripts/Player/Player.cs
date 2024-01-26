using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Player : MonoBehaviour
{
    private ReactiveProperty<int> _health = new();
    private ReactiveProperty<int> _ammo = new();
    private ReactiveProperty<int> _maxAmmo = new();
    private ReactiveProperty<PlayerActionType> _actionType = new();

    public ReactiveProperty<int> Health => _health;
    public ReactiveProperty<int> Ammo => _ammo;
    public ReactiveProperty<int> MaxAmmo => _maxAmmo;
    public ReactiveProperty<PlayerActionType> ActionType => _actionType;

    public float HitChance => _ammo.Value / _maxAmmo.Value;

    public abstract void UseUltimate();
}

public enum PlayerActionType
{
    Attack,
    Dodge,
    Reload
}