using System;

public abstract class Player
{
    private static Random s_rand = new Random();

    protected PlayerType _playerType;
    protected int _maxHealth;
    protected int _health;
    protected int _ammo;
    protected int _maxAmmo;
    protected PlayerActionType _actionType;

    public PlayerType PlayerType => _playerType;
    public int MaxHealth => _maxHealth;
    public int Health => _health;
    public int Ammo => _ammo;
    public int MaxAmmo => _maxAmmo;
    public PlayerActionType ActionType => _actionType;

    public bool IsShootingSuccess => (_ammo / _maxAmmo) * 1000 < s_rand.Next(0, 1000);
    public bool IsUltimateUsed { get; set; } = false;

    public void ResetFlags()
    {
        IsUltimateUsed = false;
    }

    public virtual void ReloadAmmo()
    {
        _ammo = Math.Clamp(_ammo + 1, 0, _maxAmmo);
    }

    public virtual void GetDamage()
    {
        if (_actionType != PlayerActionType.Dodge)
            _health = Math.Clamp(_health - 1, 0, _maxHealth);
    }

    public virtual void Fire(Player enemy)
    {
        _ammo = Math.Clamp(_ammo - 1, 0, _maxAmmo);

        if (IsShootingSuccess)
            enemy.GetDamage();
    }
}

public enum PlayerActionType
{
    Attack,
    Dodge,
    Reload
}