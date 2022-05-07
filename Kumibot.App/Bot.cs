﻿using System.Reflection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Kumibot.App.Clients;
using Kumibot.App.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kumibot.App;

public static class Bot
{
    private static DiscordSocketClient _client;
    private static CommandService _commands;
    private static GameRepository _gameRepository;
    private static WalletRepository _walletRepository;
    private static IServiceProvider _services;

    public static async Task RunBotAsync()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables()
            .Build();
        
        _client = new DiscordSocketClient();
        _commands = new CommandService();
        _gameRepository = new GameRepository();
        _walletRepository = new WalletRepository();
        _services = new ServiceCollection()
            .AddSingleton(_gameRepository)
            .AddSingleton(_walletRepository)
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .AddSingleton<IConfiguration>(_ => configuration)
            .AddScoped<SportRadarClient>()
            .AddScoped<SportRadarRepository>()
            .AddScoped<SportsDataIOClient>()
            .AddScoped<SportsDataIORepository>()
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
            if (message.HasStringPrefix("<@971933186743472128> ", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }
        }
    }
}