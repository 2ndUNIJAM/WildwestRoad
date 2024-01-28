using System;

public class Langer : Player
{
    public Langer()
    {
        _maxHealth = 4;
        _health = 4;
        _maxAmmo = 6;
        _ammo = 1;
        _playerType = PlayerType.A;
    }

    public override void ReloadAmmo()
    {
        var rand = new Random();

        if (rand.Next(0, 2) == 0)
        {
            _ammo = Math.Clamp(_ammo + 2, 0, _maxAmmo);
            IsUltimateUsed = true;
        }
        else
        {
            _ammo = Math.Clamp(_ammo + 1, 0, _maxAmmo);
            IsUltimateUsed = false;
        }
    }
}