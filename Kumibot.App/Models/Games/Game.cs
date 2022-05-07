using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Kumibot.App.Models.Games;

public class Game
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public List<League> Leagues { get; set; }
    public List<Fighter> Fighters { get; set; }
}

public class League
{
    public List<Event> Events { get; set; }
    public List<Fighter> Champions { get; set; }
}

public class Event
{
    public string Name { get; set; }
    public List<MatchUp> MatchUps { get; set; }

    public class MatchUp
    {
        public Fighter FighterOne { get; set; }
        public Fighter FighterTwo { get; set; }
    }
}

public class Fighter
{
    public string Name { get; set; }
    public List<WeightClass> WeightClasses { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Draws { get; set; }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum WeightClass
{
    Strawweight,
    Flyweight,
    Batamweight,
    Featherweight,
    Lightweight,
    SuperLightweight,
    Welterweight,
    SuperWelterweight,
    Middleweight,
    SuperMiddleweight,
    LightHeavyweight,
    Cruiserweight,
    Heavyweight,
    SuperHeavyweight
}