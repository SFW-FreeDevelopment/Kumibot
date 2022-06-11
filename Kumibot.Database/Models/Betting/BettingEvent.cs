using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Kumibot.Database.Models.Betting;
public class BettingEvent : BaseResource
{
    public string CombatEventId { get; set; }
    public List<Bet> Bets { get; set; } = new();
}