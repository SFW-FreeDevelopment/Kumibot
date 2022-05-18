using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace Kumibot.App.Interactions;

public class InteractionBase : InteractionModuleBase<SocketInteractionContext>
{
    protected SocketUser User => Context.User;
    protected IGuildUser GuildUser => (IGuildUser)User;
    protected SocketInteraction Interaction => Context.Interaction;
    protected string Mention => User.Mention;
}