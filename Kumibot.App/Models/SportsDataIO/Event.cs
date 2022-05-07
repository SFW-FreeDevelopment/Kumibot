namespace Kumibot.App.Models.SportsDataIO;

public class Event
{
    public int EventId { get; set; }
    public int LeagueId { get; set; }
    public string Name { get; set; }
    public string ShortName { get; set; }
    public int Season { get; set; }
    public DateTime Day { get; set; }
    public DateTime DateTime { get; set; }
    public string Status { get; set; }
    public bool Active { get; set; }
}