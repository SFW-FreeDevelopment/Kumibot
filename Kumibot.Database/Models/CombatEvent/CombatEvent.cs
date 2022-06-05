namespace Kumibot.Database.Models.CombatEvent;

public class CombatEvent : BaseResource
{
    public string EventTitle { get; set; }
    public List<Match> Matches { get; set; }
    public CombatEventType Type { get; set; }
    public CombatEventSubType? SubType { get; set; }
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