namespace Kumibot.Database.Models.Combat;

public class CombatEvent : BaseResource
{
    public string EventTitle { get; set; }
    public List<Match> Matches { get; set; }
    public CombatEventType Type { get; set; }
    public CombatEventSubType? SubType { get; set; }
    public CombatEventStatus Status { get; set; } = CombatEventStatus.Created;
}

public enum CombatEventType
{
    FightCard,
    SingleExhibition,
    Team,
    TeamTournament,
    Tournament
}

public enum CombatEventSubType
{
    Grudge,
    Rival,
    Title
}

public enum CombatEventStatus
{
    Created,
    Pending,
    Running,
    Processing,
    Finished
}