using Discord;

namespace Kumibot.App.Interactions.Components;

public interface IKumibotComponent<T> where T : Dictionary<string, string>
{
    public ComponentBuilder Get();
}