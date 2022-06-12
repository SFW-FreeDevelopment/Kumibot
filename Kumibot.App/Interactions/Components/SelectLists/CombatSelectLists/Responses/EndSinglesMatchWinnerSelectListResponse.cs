using Discord;
using Discord.Interactions;
using Kumibot.App.Helpers;
using Kumibot.App.Services;
using Kumibot.Exceptions;

namespace Kumibot.App.Interactions.Components.SelectLists.CombatSelectLists.Responses;

public class EndSinglesMatchWinnerSelectListResponse : InteractionBase
{
    private readonly CombatService _combatService;
    private readonly FighterService _fighterService;
    private readonly BettingService _bettingService;

    public EndSinglesMatchWinnerSelectListResponse(CombatService combatService, FighterService fighterService,
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
            if (splitValues is { Length: > 3 })
            {
                var combatEventId = splitValues[0];
                var matchRound = int.Parse(splitValues[1]);
                var matchPosition = int.Parse(splitValues[2]);
                var winnerId = splitValues[3];
                var combatEvent =
                    await _combatService.GetById(combatEventId);
                if (combatEvent != null)
                {
                    var match = combatEvent.Matches.FirstOrDefault(x =>
                        x.Round.Equals(matchRound) && x.Position.Equals(matchPosition));
                    if (match != null)
                    {
                        var winner = await _fighterService.GetById(winnerId);
                        if (winner != null)
                        {
                            match.Winner = winner.Id;
                            await _combatService.Update(combatEvent.Id, combatEvent);
                            var resultMessages = await _bettingService.ProcessBetsForMatch(combatEvent.Id, match);
                            foreach (var resultMessage in resultMessages)
                            {
                                await ReplyAsync(resultMessage);
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