using Kumibot.Database.Models.Combat;

namespace Kumibot.Database.Models.Betting;

public class Bet
{
    public double DollarAmount { get; set; }
    public string FighterId { get; set; }
    public int MatchPosition { get; set; }
    public int MatchRound { get; set; }
    public bool Processed { get; set; }
}