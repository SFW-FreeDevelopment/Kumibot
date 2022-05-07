namespace Kumibot.App;

public static class Constants
{
    public static readonly string HelpMessage = $"**The following commands can be used:**{Environment.NewLine}" +
                                                $"  • **help** - Assists the user by displaying all commands{Environment.NewLine}" +
                                                $"  • **ping** - Pings the Discord channel{Environment.NewLine}" +
                                                $"  • **champions** - Prints a list of the current UFC champions by weight class{Environment.NewLine}" +
                                                $"  • **competitions** - Prints a list of upcoming UFC events{Environment.NewLine}" +
                                                "  • **fights** - 	Prints a list of upcoming UFC fights";
    
    public const string PingMessage = "I am pinging the server.";
}