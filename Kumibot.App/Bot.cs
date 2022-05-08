using System.Reflection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Kumibot.App.Clients;
using Kumibot.App.Repositories;
using Kumibot.App.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kumibot.App;

public static class Bot
{
    private static DiscordSocketClient _client;
    private static CommandService _commands;
    private static IServiceProvider _services;

    public static async Task RunBotAsync()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables()
            .Build();
        
        _client = new DiscordSocketClient();
        _commands = new CommandService();
        _services = new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .AddSingleton<IConfiguration>(_ => configuration)
            .AddSingleton<GameRepository>()
            .AddSingleton<WalletRepository>()
            .AddSingleton<BettingEventRepository>()
            .AddScoped<SportRadarClient>()
            .AddScoped<SportRadarRepository>()
            .AddScoped<SportsDataIOClient>()
            .AddScoped<SportsDataIORepository>()
            .AddScoped<BettingService>()
            .BuildServiceProvider();
        
        _client.Log += Log;

        await RegisterCommandsAsync();

        await _client.LoginAsync(TokenType.Bot, configuration["DiscordBotToken"]);

        await _client.StartAsync();

        await Task.Delay(-1);
    }

    private static Task Log(LogMessage arg)
    {
        Console.WriteLine(arg);
        return Task.CompletedTask;
    }
        
    private static async Task RegisterCommandsAsync()
    {
        _client.MessageReceived += HandleCommandAsync;
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
    }

    private static async Task HandleCommandAsync(SocketMessage socketMessage)
    {
        var message = socketMessage as SocketUserMessage;
        var context = new SocketCommandContext(_client, message);
        if (message is null || message.Author.IsBot) return;

        int argPos = 0;
        if (message.HasStringPrefix("kumibot ", ref argPos))
        {
            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess)
                Console.WriteLine(result.ErrorReason);
        }
        else
        {
            argPos = 0;
            if (message.HasStringPrefix($"<@{Constants.BotUserId}> ", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }
        }
    }
}
