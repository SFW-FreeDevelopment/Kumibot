using System.Net;
using Kumibot.App.Helpers;
using Kumibot.Database.Models.Betting;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Betting;
using Kumibot.Database.Repositories.Combat;
using Kumibot.Exceptions;

namespace Kumibot.App.Services;

public class BettingService : IKumibotService<BettingEvent>
{
    private readonly BettingEventRepository _bettingEventRepository;
    private readonly CombatEventRepository _combatEventRepository;
    private readonly FighterRepository _fighterRepository;
    private readonly WalletRepository _walletRepository;

    public BettingService(BettingEventRepository bettingEventRepository, CombatEventRepository combatEventRepository, WalletRepository walletRepository, FighterRepository fighterRepository)
    {
        _bettingEventRepository = bettingEventRepository;
        _combatEventRepository = combatEventRepository;
        _walletRepository = walletRepository;
        _fighterRepository = fighterRepository;
    }

    public Task<List<BettingEvent>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<BettingEvent> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<BettingEvent> Create(BettingEvent data)
    {
        throw new NotImplementedException();
    }

    public Task<BettingEvent> Update(string id, BettingEvent data)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<BettingEvent> GetByCombatEventId(string combatEventId)
    {
        var events = await _bettingEventRepository.GetActiveBettingEvents();
        return events.FirstOrDefault(x => x.CombatEventId.Equals(combatEventId));
    }
    
    public async Task<List<string>> ProcessBetsForMatch(string combatEventId, Match match)
    {
        var targetEvent = await GetByCombatEventId(combatEventId);
        if (targetEvent is null) throw new KumibotException(HttpStatusCode.NotFound);
        var fighterOne = await _fighterRepository.GetById(match.FighterOneId);
        var fighterTwo = await _fighterRepository.GetById(match.FighterTwoId);
        var resultMessages = new List<string>();
        foreach (var bet in targetEvent.Bets.Where(x => x.MatchRound.Equals(match.Round) && x.MatchPosition.Equals(match.Position)))
        {
            var userWallet = await _walletRepository.GetByDiscordOwner(bet.DiscordOwner);
            if (bet.FighterId.Equals(match.Winner))
            {
                var odds = targetEvent.Odds.FirstOrDefault(x => x.MatchRound.Equals(match.Round) && x.MatchPosition.Equals(match.Position));
                if (odds == null) throw new KumibotException();
                var winnerOdds = odds.FighterOneId.Equals(match.Winner) ? odds.FighterOneOdds : odds.FighterTwoOdds;
                var profit = BettingHelper.CalculateProfit(bet.DollarAmount, winnerOdds);
                userWallet.Dollars += profit;
                await _walletRepository.Update(userWallet.Id, userWallet);
                resultMessages.Add($"<@{bet.DiscordOwner}> won ${bet.DollarAmount} on {fighterOne.Name} vs {fighterTwo.Name}!");
            }
            else
            {
                userWallet.Dollars -= bet.DollarAmount;
                await _walletRepository.Update(userWallet.Id, userWallet);
                resultMessages.Add($"<@{bet.DiscordOwner}> lost ${bet.DollarAmount} on {fighterOne.Name} vs {fighterTwo.Name}!");
            }
        }
        return resultMessages;
    }
}