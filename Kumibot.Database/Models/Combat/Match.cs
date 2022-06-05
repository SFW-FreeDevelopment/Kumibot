namespace Kumibot.Database.Models.Combat;

public class Match
{
    public string FighterOneId { get; set; }
    public string FighterTwoId { get; set; }
    public int Position { get; set; } = -1;
    public int Round { get; set; } = 1;
    public string Winner { get; set; }
}