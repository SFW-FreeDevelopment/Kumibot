namespace Kumibot.Database.Models.Betting;

public class Bet
{
    public ulong Owner { get; set; }
    public double DollarAmount { get; set; }
    public long FighterId { get; set; }
    public string Fighter { get; set; }
    public int MatchUpPosition { get; set; }
    public bool Processed { get; set; }
}