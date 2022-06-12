namespace Kumibot.Database.Models.Betting;

public class Odds
{
    public string FighterOneId { get; set; }
    public int FighterOneOdds { get; set; }
    public string FighterTwoId { get; set; }
    public int FighterTwoOdds { get; set; }
    public int MatchRound { get; set; }
    public int MatchPosition { get; set; }
}