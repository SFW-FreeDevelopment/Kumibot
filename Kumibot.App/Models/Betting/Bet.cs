namespace Kumibot.App.Models.Betting;

public class Bet
{
    public long Owner { get; set; }
    public double DollarAmount { get; set; }
    public string Fighter { get; set; }
}