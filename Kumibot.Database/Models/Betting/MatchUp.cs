using Kumibot.Database.Models.Combat;

namespace Kumibot.Database.Models.Betting;

public class MatchUp
{
    public Fighter FighterOne { get; set; }
    public Fighter FighterTwo { get; set; }
    public int FighterOneOdds { get; set; }
    public int FighterTwoOdds { get; set; }
    public string WinnerId { get; set; }
    public bool Finished { get; set; }
    public int Position { get; set; }
}