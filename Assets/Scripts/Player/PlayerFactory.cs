using System;

public class PlayerFactory
{
    public Player CreatePlayer(PlayerType playerType) => playerType switch
    {
        PlayerType.A => new Langer(),
        PlayerType.B => new Loki(),
        PlayerType.C => new Max(),
        PlayerType.D => new Nadesiko(),
        _ => throw new InvalidOperationException("Invalid player type")
    };
}