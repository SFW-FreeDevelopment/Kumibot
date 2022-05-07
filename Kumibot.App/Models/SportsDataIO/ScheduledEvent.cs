namespace Kumibot.App.Models.SportsDataIO;

public class ScheduledEvent
{
    public long EventId { get; set; }
    public long LeagueId { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public int Season { get; set; }
    public DateTime Day { get; set; }
    public DateTime DateTime { get; set; }
    public string Status { get; set; }
    public bool Active { get; set; }
    public List<Fight> Fights { get; set; }
}