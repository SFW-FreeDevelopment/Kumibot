using Kumibot.App.Models.Betting;

namespace Kumibot.App.Services;

public class BettingService
{
    private BettingEvent BettingEvent { get; set; }

    public bool CreateEvent(BettingEvent bettingEvent)
    {
        BettingEvent = bettingEvent;
        return BettingEvent is not null;
    }

    public string GetEventTitle()
    {
        return BettingEvent.EventTitle;
    }

    public List<Bet> GetBets()
    {
        return BettingEvent.Bets;
    }
    
    public List<Tuple<string, string>> GetMatchUps()
    {
        return BettingEvent.MatchUps;
    }

    public bool AddBet(Bet bet)
    {
        BettingEvent.Bets.Add(bet);
        return BettingEvent.Bets.Contains(bet);
    }
}