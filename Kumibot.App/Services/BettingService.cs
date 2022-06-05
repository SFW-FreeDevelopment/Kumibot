//using Kumibot.App.Models.Betting;

using Kumibot.Database.Repositories;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Services;

public class BettingService
{
    private BettingEventRepository _bettingEventRepository { get; set; }

    public BettingService(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }

    // public bool StartEvent(BettingEvent bettingEvent)
    // {
    //     if (_bettingEventRepository.GetBettingEvents().Exists(be => be.EventTitle.Equals(bettingEvent.EventTitle)))
    //         return false;
    //     var newEvent = _bettingEventRepository.AddBettingEvent(bettingEvent);
    //     if (newEvent is not null)
    //         _bettingEventRepository.UpdateBettingEventStatus(newEvent.EventTitle, BettingEventStatus.RUNNING);
    //     return newEvent is not null;
    // }
    //
    // public List<BettingEvent> GetBettingEvents()
    // {
    //     return _bettingEventRepository.GetBettingEvents();
    // }
    //
    // public List<MatchUp> GetMatchUps(string eventTitle)
    // {
    //     var bettingEvent = _bettingEventRepository.GetBettingEventByEventTitle(eventTitle);
    //     return bettingEvent?.MatchUps;
    // }
    //
    // public bool AddMatchUp(string eventTitle, MatchUp matchUp)
    // {
    //     var updatedEvent = _bettingEventRepository.AddMatchUp(eventTitle, matchUp);
    //     return updatedEvent is not null;
    // }
    //
    // public bool SetWinner(string eventTitle, int position, long winnerId)
    // {
    //     var updatedEvent = _bettingEventRepository.EndMatchUp(eventTitle, position, winnerId);
    //     return updatedEvent is not null;
    // }
    //
    // public List<Bet> GetBets(string eventTitle)
    // {
    //     var bettingEvent = _bettingEventRepository.GetBettingEventByEventTitle(eventTitle);
    //     return bettingEvent.Bets;
    // }
    //
    // public bool AddBet(string eventTitle, Bet bet)
    // {
    //     var newBet = _bettingEventRepository.AddBet(eventTitle, bet);
    //     return newBet is not null;
    // }
}