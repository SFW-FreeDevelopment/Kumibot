using System.Text.Json;
using Kumibot.App.Models.Betting;

namespace Kumibot.App.Repositories;

public class BettingEventRepository
{
    private readonly List<BettingEvent> _bettingEvents;
    private readonly StreamReader _bettingEventsStream;
    private readonly string _sFile;
    
    public BettingEventRepository()
    {
        var sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;            
        _sFile = Path.Combine(sCurrentDirectory, @"..\..\..\Data\bettingEvents.json");
        _bettingEventsStream = new StreamReader(Path.GetFullPath(_sFile));
        _bettingEvents = JsonSerializer.Deserialize<List<BettingEvent>>(_bettingEventsStream.ReadToEnd());
        _bettingEventsStream.Close();
    }

    public List<BettingEvent> GetBettingEvents()
    {
        return _bettingEvents;
    }
    
    public BettingEvent GetBettingEventByEventTitle(string eventTitle)
    {
        return _bettingEvents.FirstOrDefault(be => be.EventTitle.Equals(eventTitle));
    }
    
    public BettingEvent AddBettingEvent(BettingEvent bettingEvent)
    {
        if (_bettingEvents.Contains(bettingEvent))
        {
            return bettingEvent;
        }
        _bettingEvents.Add(bettingEvent);
        File.WriteAllText(_sFile, JsonSerializer.Serialize(_bettingEvents));
        return _bettingEvents.FirstOrDefault(be => be.EventTitle.Equals(bettingEvent.EventTitle));
    }

    public BettingEvent UpdateBettingEventStatus(string eventTitle, BettingEventStatus status)
    {
        var eventToUpdate = _bettingEvents.FirstOrDefault(be => be.EventTitle.Equals(eventTitle));
        if (eventToUpdate is null) return null;
        eventToUpdate.Status = status;
        eventToUpdate.UpdatedAt = DateTime.Now;
        File.WriteAllText(_sFile, JsonSerializer.Serialize(_bettingEvents));
        return eventToUpdate;
    }
    
    public BettingEvent EndEvent(string eventTitle)
    {
        var eventToUpdate = _bettingEvents.FirstOrDefault(be => be.EventTitle.Equals(eventTitle));
        if (eventToUpdate is null) return null;
        foreach (var matchUp in eventToUpdate.MatchUps)
        {
            matchUp.Finished = true;
        }
        eventToUpdate.Finished = true;
        eventToUpdate.UpdatedAt = DateTime.Now;
        File.WriteAllText(_sFile, JsonSerializer.Serialize(_bettingEvents));
        return eventToUpdate;
    }
    
    public BettingEvent AddMatchUp(string eventTitle, MatchUp matchUp)
    {
        var eventToUpdate = _bettingEvents.FirstOrDefault(be => be.EventTitle.Equals(eventTitle));
        if (eventToUpdate is null) return null;
        matchUp.Position = eventToUpdate.MatchUps.Count + 1;
        eventToUpdate.MatchUps.Add(matchUp);
        eventToUpdate.UpdatedAt = DateTime.Now;
        File.WriteAllText(_sFile, JsonSerializer.Serialize(_bettingEvents));
        return eventToUpdate;
    }
    
    public BettingEvent EndMatchUp(string eventTitle, int matchUpPosition)
    {
        var eventToUpdate = _bettingEvents.FirstOrDefault(be => be.EventTitle.Equals(eventTitle));
        var matchUp = eventToUpdate?.MatchUps.FirstOrDefault(mu => mu.Position.Equals(matchUpPosition));
        if (matchUp is null) return null;
        matchUp.Finished = true;
        eventToUpdate.UpdatedAt = DateTime.Now;
        File.WriteAllText(_sFile, JsonSerializer.Serialize(_bettingEvents));
        return eventToUpdate;
    }
    
    public BettingEvent AddBet(string eventTitle, Bet bet)
    {
        var eventToUpdate = _bettingEvents.FirstOrDefault(be => be.EventTitle.Equals(eventTitle));
        if (eventToUpdate is null) return null;
        var existingBet = eventToUpdate.Bets.FirstOrDefault(b => b.Owner.Equals(bet.Owner));
        if (existingBet is not null) return null;
        eventToUpdate.Bets.Add(bet);
        eventToUpdate.UpdatedAt = DateTime.Now;
        File.WriteAllText(_sFile, JsonSerializer.Serialize(_bettingEvents));
        return eventToUpdate;
    }
}