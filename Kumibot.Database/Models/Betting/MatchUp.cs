namespace Kumibot.Database.Models.Betting;

public class MatchUp
{
    public long? FighterOneId { get; set; }
    public long? FighterTwoId { get; set; }
    public string FighterOne { get; set; }
    public string FighterTwo { get; set; }
    public int FighterOneOdds { get; set; }
    public int FighterTwoOdds { get; set; }
    public string Winner { get; set; }
    public bool Finished { get; set; }
    public int Position { get; set; }
}