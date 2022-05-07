namespace Kumibot.App.Models.SportsDataIO;

public class Fighter
{
    public long FighterId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PreFightWins { get; set; }
    public int PreFightLosses { get; set; }
    public int PreFightDraws { get; set; }
    public int PreFightNoContests { get; set; }
    public bool Winner { get; set; }
    public int? Moneyline { get; set; }
    public bool Active { get; set; }
}