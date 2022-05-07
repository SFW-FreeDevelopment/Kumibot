namespace Kumibot.App.Models.SportsDataIO;

public class Fight
{
    public long FightId { get; set; }
    public int? Order { get; set; }
    public string Status { get; set; }
    public string WeightClass { get; set; }
    public string CardSegment { get; set; }
    public string Referee { get; set; }
    public int Rounds { get; set; }
    public int ResultClock { get; set; }
    public int ResultRound { get; set; }
    public string ResultType { get; set; }
    public object WinnerId { get; set; }
    public bool Active { get; set; }
    public List<Fighter> Fighters { get; set; }
}