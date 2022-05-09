namespace Kumibot.Database.Models.Betting;

public class Wallet : BaseResource
{
    public ulong Owner { get; set; }
    public double Dollars { get; set; }
}