using Discord;

namespace Kumibot.App.Helpers;

public static class SelectListHelper
{
    public static ComponentBuilder GetSelectList(string customId, Dictionary<string, string> listOptions)
    {
        var selectMenuBuilder = new SelectMenuBuilder().WithCustomId(customId);
        foreach (var option in listOptions)
        {
            selectMenuBuilder.AddOption($"{option.Key}", $"{option.Value}");
        }
        return new ComponentBuilder().WithSelectMenu(selectMenuBuilder);
    }
}