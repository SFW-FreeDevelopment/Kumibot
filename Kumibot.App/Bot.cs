using System.Reflection;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Kumibot.App.Clients;
using Kumibot.App.Repositories;
using Kumibot.App.Services;
using Kumibot.Database.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Kumibot.App;

public static class Bot
{
    private static DiscordSocketClient _client;
    private static CommandService _commands;
    private static InteractionService _interactions;
    private static IServiceProvider _services;

    public static async Task RunBotAsync()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables()
            .Build();
        
        _client = new DiscordSocketClient();
        _commands = new CommandService();
        _interactions = new InteractionService(_client.Rest);
        _services = new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .AddSingleton(x => new InteractionService(x.GetRequiredService<DiscordSocketClient>()))
            .AddSingleton<IConfiguration>(_ => configuration)
            .AddScoped<IMongoClient, MongoClient>(_ => new MongoClient(MongoClientSettings.FromConnectionString(configuration["MongoDatabaseConnectionString"])))
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
        
        _client.Ready += RegisterInteractionsAsync;

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
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        _client.MessageReceived += HandleCommandAsync;
    }

    private static async Task RegisterInteractionsAsync()
    {
        await _interactions.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        await _interactions.RegisterCommandsToGuildAsync(698640831363547157, false);
        _client.InteractionCreated += HandleInteractionAsync;
        _client.ModalSubmitted += HandleModalAsync;
    }

    private static async Task HandleCommandAsync(SocketMessage socketMessage)
    {
        var message = socketMessage as SocketUserMessage;
        var context = new SocketCommandContext(_client, message);
        if (message is null || message.Author.IsBot) return;

        var argPos = 0;
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

    private static async Task HandleInteractionAsync(SocketInteraction socketInteraction)
    {
        var context = new SocketInteractionContext(_client, socketInteraction);
        var result = await _interactions.ExecuteCommandAsync(context, _services);
        if (!result.IsSuccess)
            Console.WriteLine(result.ErrorReason);
    }
    
    private static async Task HandleModalAsync(SocketModal modal)
    {
        await modal.DeferAsync();
    }
}
