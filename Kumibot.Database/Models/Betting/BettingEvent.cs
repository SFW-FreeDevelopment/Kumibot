using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Kumibot.Database.Models.Betting;
public class BettingEvent : BaseResource
{
    public string EventId { get; set; }
    public List<Bet> Bets { get; set; } = new();
    public List<string> ResultMessages { get; set; } = new();
    public BettingEventStatus Status { get; set; } = BettingEventStatus.Created;
    public string EventTitle { get; set; }
    public List<MatchUp> MatchUps { get; set; } = new();
    public BettingEventType Type { get; set; } = BettingEventType.Single;
    public DateTime? StartsOnDate { get; set; }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum BettingEventStatus
{
    Created,
    Running,
    Processing,
    Finished
}

[JsonConverter(typeof(StringEnumConverter))]
public enum BettingEventType
{
    Single,
    FightCard,
    Tournament
}