namespace Kumibot.App;

public static class Constants
{
    public const string BotUserId = "971933186743472128";
    
    public static readonly string HelpMessage = $"**The following commands can be used:**{Environment.NewLine}" +
                                                $"  • **help** - Assists the user by displaying all commands{Environment.NewLine}" +
                                                $"  • **ping** - Pings the Discord channel{Environment.NewLine}" +
                                                $"  • **champions** - Prints a list of the current UFC champions by weight class{Environment.NewLine}" +
                                                $"  • **competitions** - Prints a list of upcoming UFC events{Environment.NewLine}" +
                                                "  • **fights** - 	Prints a list of upcoming UFC fights";

    public const string NeededValues = "Needed Values";
    public const string NeededValuesId = "needed_values";
    
    public const string PingMessage = "I am pinging the server.";

    #region ComponentIds

    public const string EndMatchCombatEventSelectListId = "end_match_combat_event_select_list";
    public const string PlaceBetCombatEventSelectListId = "place_bet_combat_event_select_list";
    public const string PlaceBetFighterSelectListId = "place_bet_fighter_select_list";
    public const string PlaceBetModal = "place_bet_modal";
    public const string StartCombatEventCombatEventSelectListId = "start_combat_event_combat_event_select_list";

    #endregion
}