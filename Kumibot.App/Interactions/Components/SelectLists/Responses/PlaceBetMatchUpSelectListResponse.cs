using Discord;
using Discord.Interactions;
using Kumibot.Database.Repositories;
using Kumibot.Database.Repositories.Betting;

namespace Kumibot.App.Interactions.Components.SelectLists.Responses;

public class PlaceBetMatchUpSelectListResponse : InteractionBase
{
    private readonly BettingEventRepository _bettingEventRepository;
    
    public PlaceBetMatchUpSelectListResponse(BettingEventRepository bettingEventRepository)
    {
        _bettingEventRepository = bettingEventRepository;
    }

    [ComponentInteraction("place_bet_match_up_select_list")]
    public async Task ComponentResponse()
    {
        var interaction = (IComponentInteraction)Interaction;
        var valueCombo = interaction.Data.Values.FirstOrDefault();
        var splitValue = valueCombo?.Split('_');
        var bettingEventId = splitValue?[0];
        var matchUpPosition = splitValue?[1];
        var bettingEvent =
            await _bettingEventRepository.GetBettingEventById(bettingEventId ?? string.Empty);
        var matchUp = bettingEvent.MatchUps.FirstOrDefault(x => x.Position.Equals(int.Parse(matchUpPosition ?? string.Empty)));
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId("place_bet_fighter_select_list");
        if (matchUp != null)
        {
            selectMenuBuilder.AddOption($"{matchUp.FighterOne.Name} {GetOddsSign(matchUp.FighterOneOdds)}{Math.Abs(matchUp.FighterOneOdds)}",
                $"{bettingEventId}_{matchUp.Position}_{matchUp.FighterOne.Id}");
            selectMenuBuilder.AddOption($"{matchUp.FighterTwo.Name} {GetOddsSign(matchUp.FighterTwoOdds)}{Math.Abs(matchUp.FighterTwoOdds)}",
                $"{bettingEventId}_{matchUp?.Position}_{matchUp.FighterTwo.Id}");
        }

        var builder = new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
        await RespondAsync("Select the fighter to bet on:", components: builder.Build());
    }
    
    private static char GetOddsSign(int odds)
    {
        return odds > 0 ? '+' : '-';
    }
}