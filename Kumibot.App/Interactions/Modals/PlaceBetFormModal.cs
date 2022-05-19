using Discord.Interactions;

namespace Kumibot.App.Interactions.Modals;

[Group("kumibot", "Kumibot commands")]
public class PlaceBetFormModal : IModal
{
    public string Title => "Place Bets";
}