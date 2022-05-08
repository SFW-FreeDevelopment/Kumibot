﻿namespace Kumibot.App.Models.Betting;

public class Bet
{
    public ulong Owner { get; set; }
    public double DollarAmount { get; set; }
    public string Fighter { get; set; }
    public bool Processed { get; set; }
}