using System;

public class Langer : Player
{
    public Langer()
    {
        _maxHealth = 5;
        _maxAmmo = 6;
        _ammo = 1;
        _playerType = PlayerType.A;
    }

    public override void ReloadAmmo()
    {
        IsUltimateUsed = UseUltimate();
    }

    private bool UseUltimate()
    {
        var rand = new Random();

        if (rand.Next(0, 2) == 0)
        {
            ReloadAmmo();
            return true;
        }

        return false;
    }
}