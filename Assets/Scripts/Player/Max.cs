using System;
using System.ComponentModel;

public class Max : Player
{
    public Max()
    {
        _maxHealth = 3;
        _health = 3;
        _maxAmmo = 20;
        _ammo = 3;
        _playerType = PlayerType.C;
    }

    public override void Fire(Player enemy)
    {
        IsUltimateUsed = true;

        for (int i = 0; i < 3; i++)
        {
            if (TryFire())
            {
                enemy.GetDamage();
          
            }
        }
    }
    public override void GetDamage()
    {
        base.GetDamage();
    }
}
