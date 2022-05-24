using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Kumibot.Database.Models.Betting;
// TODO: Add BettingEventType enum
public class BettingEvent : BaseResource
{
    public string EventTitle { get; set; }
    public List<MatchUp> MatchUps { get; set; } = new();
    public List<Bet> Bets { get; set; } = new();
    public BettingEventStatus Status { get; set; } = BettingEventStatus.CREATED;
    public bool Finished { get; set; }
    public DateTime? StartsOnDate { get; set; }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum BettingEventStatus
{
    CREATED,
    RUNNING,
    PROCESSING,
    FINISHED
}