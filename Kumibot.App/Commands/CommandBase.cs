using Discord;
using Discord.Commands;
using Discord.WebSocket;
// ReSharper disable MemberCanBePrivate.Global

namespace Kumibot.App.Commands;

public class CommandBase : ModuleBase<SocketCommandContext>
{
    protected SocketUser User => Context.Message.Author;
    protected IGuildUser GuildUser => (IGuildUser)User;
    protected string Mention => User.Mention;
}