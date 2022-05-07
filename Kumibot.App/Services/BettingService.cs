using Kumibot.App.Models.Betting;

namespace Kumibot.App.Services;

public class BettingService
{
    private BettingEvent BettingEvent { get; set; }

    public bool StartEvent(BettingEvent bettingEvent)
    {
        BettingEvent = bettingEvent;
        if (BettingEvent is not null)
            BettingEvent.Status = BettingEventStatus.RUNNING;
        return BettingEvent is not null;
    }

    public string GetEventTitle()
    {
        return BettingEvent.EventTitle;
    }

    public List<MatchUp> GetMatchUps()
    {
        return BettingEvent.MatchUps;
    }
    
    public bool AddMatchUp(MatchUp matchUp)
    {
        BettingEvent.MatchUps.Add(matchUp);
        return BettingEvent.MatchUps.Contains(matchUp);
    }

    public bool SetWinner(int order, string winner)
    {
        var matchUp = BettingEvent.MatchUps.FirstOrDefault(mu => mu.Order.Equals(order));
        if (matchUp == null) return false;
        var confirmedWinner = matchUp.FighterOne.Equals(winner) || matchUp.FighterTwo.Equals(winner);
        if (confirmedWinner) matchUp.Winner = winner;
        return confirmedWinner;
    }
    
    public List<Bet> GetBets()
    {
        return BettingEvent.Bets;
    }

    public bool AddBet(Bet bet)
    {
        BettingEvent.Bets.Add(bet);
        return BettingEvent.Bets.Contains(bet);
    }
}