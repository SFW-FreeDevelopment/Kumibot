namespace Kumibot.App.Models.Betting;

public class BettingEvent
{
    public string EventTitle { get; set; }
    public List<Tuple<string, string>> MatchUps { get; set; }
    public List<Bet> Bets { get; set; }
}