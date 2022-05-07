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
}