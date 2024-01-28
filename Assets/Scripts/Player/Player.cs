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

    public bool TryFire()
    {
        var ret = (float)_ammo / (float)_maxAmmo * 1000;
        var rand = s_rand.Next(0, 1000);

        return ret > rand;
    }

    public bool IsUltimateUsed { get; set; } = false;

    public void ResetFlags()
    {
        IsUltimateUsed = false;
    }

    public void SetAction(PlayerActionType playerActionType)
    {
        _actionType = playerActionType;
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
        if (_ammo <= 0)
            return;

        if (TryFire())
        {
            enemy.GetDamage();
            _ammo = Math.Clamp(_ammo - 1, 0, _maxAmmo);

        }
    }

    public override string ToString()
        => $"Type: {PlayerType}, Health: {Health}, Ammo: {Ammo}, MaxAmmo: {MaxAmmo}, HitRate: {(float)_ammo / (float)_maxAmmo}, ActionType: {ActionType}, Ultimate: {IsUltimateUsed}";
}

public enum PlayerActionType
{
    Attack,
    Dodge,
    Reload
}
