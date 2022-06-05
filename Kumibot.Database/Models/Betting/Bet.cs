namespace Kumibot.Database.Models.Betting;

public class Bet
{
    public ulong Owner { get; set; }
    public double DollarAmount { get; set; }
    public Fighter Fighter { get; set; }
    public int MatchUpPosition { get; set; }
    public bool Processed { get; set; }
}