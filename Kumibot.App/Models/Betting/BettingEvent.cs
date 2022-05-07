namespace Kumibot.App.Models.Betting;

public class BettingEvent
{
    public string EventTitle { get; set; }
    public List<MatchUp> MatchUps { get; set; }
    public List<Bet> Bets { get; set; }
    public BettingEventStatus Status { get; set; } = BettingEventStatus.CREATED;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}

public enum BettingEventStatus
{
    CREATED,
    RUNNING,
    FINISHED
}