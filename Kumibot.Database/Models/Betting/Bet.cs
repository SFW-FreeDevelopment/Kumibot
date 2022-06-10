using Kumibot.Database.Models.Combat;

namespace Kumibot.Database.Models.Betting;

public class Bet : BaseResource
{
    public double DollarAmount { get; set; }
    public string CombatEventId { get; set; }
    public string FighterId { get; set; }
    public int MatchPosition { get; set; }
    public int MatchRound { get; set; }
    public bool Processed { get; set; }
}