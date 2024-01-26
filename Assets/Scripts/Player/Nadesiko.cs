using System;

public class Nadesiko : Player
{
    public Nadesiko()
    {
        _maxHealth = 4;
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
            {
                GetDamage();
            }
            else
            {
                IsUltimateUsed = true;
            }
        }
    }
}