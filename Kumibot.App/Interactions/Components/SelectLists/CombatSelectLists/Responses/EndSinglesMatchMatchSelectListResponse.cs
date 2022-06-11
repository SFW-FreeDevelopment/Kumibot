using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Exceptions;

namespace Kumibot.App.Interactions.Components.SelectLists.CombatSelectLists.Responses;

public class EndSinglesMatchMatchSelectListResponse : InteractionBase
{
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;
    private readonly BettingService _bettingService;

    public EndSinglesMatchMatchSelectListResponse(CombatService combatService, FighterService fighterService,
        BettingService bettingService)
    {
        _combatService = combatService;
        _fighterService = fighterService;
        _bettingService = bettingService;
    }

    [ComponentInteraction(Constants.EndSinglesMatchMatchSelectListId)]
    public async Task ComponentResponse()
    {
        try
        {
            var interaction = (IComponentInteraction)Interaction;
            var splitValues = interaction.Data.Values.FirstOrDefault()?.Split("_");
            if (splitValues != null)
            {
                var combatEventId = splitValues[0];
                var matchRound = int.Parse(splitValues[1]);
                var matchPosition = int.Parse(splitValues[2]);
                var combatEvent =
                    await _combatService.GetById(combatEventId);
                if (combatEvent != null)
                {
                    var match = combatEvent.Matches.FirstOrDefault(x =>
                        x.Round.Equals(matchRound) && x.Position.Equals(matchPosition));
                    if (match != null)
                    {
                        var fighterOne = await _fighterService.GetById(match.FighterOneId);
                        var fighterTwo = await _fighterService.GetById(match.FighterTwoId);
                        if (fighterOne != null && fighterTwo != null)
                        {
                            var selectListOptions = new Dictionary<string, string>();
                            selectListOptions.Add(fighterOne.Name, $"{combatEvent.Id}_{match.Round}_{match.Position}_{fighterOne.Id}");
                            selectListOptions.Add(fighterTwo.Name, $"{combatEvent.Id}_{match.Round}_{match.Position}_{fighterTwo.Id}");
                            var combatEventSelectList =
                                SelectListHelper.GetSelectList(Constants.EndSinglesMatchWinnerSelectListId, selectListOptions);
                            await RespondAsync("Select the winner of the match:", components: combatEventSelectList.Build());
                        }
                        else
                        {
                            await ReplyAsync("Cannot end match.");
                        }
                    }
                    else
                    {
                        await ReplyAsync("Cannot end match.");
                    }
                }
                else
                {
                    await ReplyAsync("Cannot end match.");
                }
            }
            else
            {
                await ReplyAsync("Could not end match.");
            }
        }
        catch (KumibotException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}