using Discord;

namespace Kumibot.Components;

public interface IKumibotComponent<T> where T : Dictionary<string, string>
{
    public ComponentBuilder Get();
}