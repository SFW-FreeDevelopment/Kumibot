using Kumibot.Database.Models.Betting;
using Kumibot.Database.Models.Combat;
using Kumibot.Database.Repositories.Betting;
using Kumibot.Database.Repositories.Combat;
using Kumibot.Database.Repositories.Gaming;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Kumibot.Web.Data;
using Kumibot.Web.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IMongoClient, MongoClient>(_ =>
        new MongoClient(
            MongoClientSettings.FromConnectionString(builder.Configuration["MongoDatabaseConnectionString"])))
    .AddScoped<GameRepository>()
    .AddScoped<WalletRepository>()
    .AddScoped<BettingEventRepository>()
    .AddScoped<CombatEventRepository>()
    .AddScoped<FighterRepository>()
    .AddScoped<ICombatService<BettingEvent>, BettingService>()
    .AddScoped<ICombatService<CombatEvent>, EventService>()
    .AddScoped<ICombatService<Fighter>, FighterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();