using Discord.Interactions;
using Kumibot.Database.Models.Betting;

namespace Kumibot.App.Interactions.Modals;

[Group("kumibot", "Kumibot commands")]
public class CreateBettingEventModal : IModal
{
    public string Title => "Create Betting Event";
    [InputLabel("Event Title")]
    [ModalTextInput("event_title", placeholder: "Fighting Event 100", maxLength: 100)]
    [RequiredInput]
    public string EventTitle { get; set; }

    [InputLabel("Add Match-ups")]
    [ModalTextInput("match_up_list", placeholder: "Fighter", maxLength: 50)]
    [RequiredInput]
    public List<MatchUp> MatchUps { get; set; } = new();
}