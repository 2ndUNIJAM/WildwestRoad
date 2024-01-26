using System;

public class Max : Player
{
    public Max()
    {
        _maxHealth = 3;
        _maxAmmo = 20;
        _ammo = 3;
        _playerType = PlayerType.C;
    }

    public override void Fire(Player enemy)
    {
        for (int i = 0; i < 3; i++)
        {
            if (IsShootingSuccess)
            {
                enemy.GetDamage();
            }
            else
            {
                _ammo = Math.Clamp(_ammo - 1, 0, _maxAmmo);
            }
        }
    }
}
