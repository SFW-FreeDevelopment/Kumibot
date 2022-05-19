namespace Kumibot.Database.Models.Betting;

public class BettingEvent : BaseResource
{
    public string EventTitle { get; set; }
    public List<MatchUp> MatchUps { get; set; } = new();
    public List<Bet> Bets { get; set; } = new();
    public BettingEventStatus Status { get; set; } = BettingEventStatus.CREATED;
    public bool Finished { get; set; }
}

public enum BettingEventStatus
{
    CREATED,
    RUNNING,
    PROCESSING,
    FINISHED
}