using System;

public class Nadesiko : Player
{
    public Nadesiko()
    {
        _maxHealth = 2;
        _health = 2;
        _maxAmmo = 5;
        _ammo = 1;
        _playerType = PlayerType.D;
    }

    public override void GetDamage()
    {
        if (_actionType != PlayerActionType.Dodge)
        {
            var rand = new Random();

            if (rand.Next(0, 2) == 0)
                _health = Math.Clamp(_health - 1, 0, _maxHealth);
            else
                IsUltimateUsed = true;
        }
    }
}